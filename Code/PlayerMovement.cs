using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementRigidbody : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;
    Vector3 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = 0f;
        float v = 0f;

        if (Keyboard.current.wKey.isPressed) v -= 1f;
        if (Keyboard.current.sKey.isPressed) v += 1f;
        if (Keyboard.current.aKey.isPressed) h += 1f;
        if (Keyboard.current.dKey.isPressed) h -= 1f;

        Vector3 input = new Vector3(h, 0f, v);

        if (input.sqrMagnitude < 0.01f)
        {
            moveInput = Vector3.zero;
            return;
        }

        input.Normalize();

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        moveInput = forward * input.z + right * input.x;
    }

    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveInput * moveSpeed * Time.fixedDeltaTime
        );
    }
}
