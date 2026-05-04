using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    private Vector2 movementDir;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpReduceRate;

    //Other Scripts
    private PlayerStats _playerStats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerStats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector2(movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
        rb.AddForce(new Vector2 (movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, 0f), ForceMode2D.Force);
        //rb.MovePosition(new Vector2(transform.position.x + (movementDir.x * moveSpeed * Time.fixedDeltaTime), transform.position.y));
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _playerStats.isGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y / jumpReduceRate);
        }
    }
}
