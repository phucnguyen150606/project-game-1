using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    public bool isDashing { get; set; }
    public Vector2 movement {  get; set; }

    private void FixedUpdate()
    {
        if (isDashing) return;
        rb.linearVelocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>().normalized;
    }
}
