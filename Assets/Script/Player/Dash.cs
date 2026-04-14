using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private PlayerMovement player;
    private bool canDashing = true;

    private Vector2 dashDir;

    //input
    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.started || !canDashing) return;
        StartCoroutine(DashDuration());
    }

    //logic
    IEnumerator DashDuration()
    {
        canDashing = false;
        player.isDashing = true;
        dashDir = player.movement;
        rb.linearVelocity = dashDir * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        rb.linearVelocity = Vector2.zero;
        player.isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDashing = true;
    }
}
