using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private float shootSpeed = 10f;
    private float shootPos;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        shootPos = spriteRender.bounds.max.y; //lay top sprite renderer lam diem ban
        shoot(new Vector2(transform.position.x, shootPos));
    }

    public void shoot(Vector2 pos)
    {
        var instace = Instantiate(bullet, new Vector2(transform.position.x, pos.y), Quaternion.identity);// Instantiate(GameObject, vector position, rotation)
        var rb = instace.GetComponent<Rigidbody2D>();
        if(rb != null) rb.linearVelocity = new Vector2(rb.linearVelocity.x, shootSpeed);
    }
}
