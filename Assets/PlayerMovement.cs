using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement_NewInputSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 150f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return; // no keyboard present

        // W / S for forward/back
        float move = 0f;
        if (keyboard.wKey.isPressed) move = 1f;
        else if (keyboard.sKey.isPressed) move = -1f;

        // A / D for rotation (like a boat)
        float rotation = 0f;
        if (keyboard.aKey.isPressed) rotation = 1f;   // rotate left
        else if (keyboard.dKey.isPressed) rotation = -1f; // rotate right

        // Apply movement and rotation
        rb.linearVelocity = transform.up * move * moveSpeed;
        rb.MoveRotation(rb.rotation + rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
