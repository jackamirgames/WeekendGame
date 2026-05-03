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
    [Space]
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementDir.x * moveSpeed * Time.fixedDeltaTime * 10f, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.AddForce(new Vector2(0f, 100f * jumpForce), ForceMode2D.Force);
        }

        if (context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y / jumpReduceRate);
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
