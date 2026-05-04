using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlast : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private PlayerStats _playerStats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerStats = GetComponent<PlayerStats>();
    }

    public void BlastDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x, 0f);
            rb.AddForce(new Vector2(0f, 100f * 4), ForceMode2D.Force);
        }
    }

    public void BlastLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(new Vector2(100f * 4, 0f), ForceMode2D.Force);
        }
    }

    public void BlastRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(new Vector2(100f * -4, 0f), ForceMode2D.Force);
        }
    }

    public void BlastUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(new Vector2(0f, 100f * -4), ForceMode2D.Force);
        }
    }
}
