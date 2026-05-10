using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class PlayerBlast : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private PlayerStats _playerStats;
    private PlayerAudio _playerAudio;

    //Timers
    [SerializeField] private float holdBlastTimer;
    private float[] _blastTimers; //0 - Down, 1 - Left, 2 - Right, 3 - Up

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerStats = GetComponent<PlayerStats>();
        _playerAudio = GetComponent<PlayerAudio>();

        _blastTimers = new float[4];
    }

    private void Update()
    {
        //Checks for timers
        for (int i = 0; i < _blastTimers.Length; i++)
        {
            if (_blastTimers[i] >= 0)
            {
                _blastTimers[i] += Time.deltaTime;
            }
        }
    }

    public void BlastDown(InputAction.CallbackContext context)
    {
        if (_playerStats.isGrounded()) return;

        _playerAudio.PlayBlastSFX();

        if (context.performed)
        {
            _blastTimers[0] = 0f;
        }

        if (context.canceled)
        {
            if (_blastTimers[0] > holdBlastTimer) //Blast Jump
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(new Vector2(0f, 100f * 7), ForceMode2D.Force);
            }
            else //Normal Jump
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(new Vector2(0f, 100f * 4), ForceMode2D.Force);
            }

            _blastTimers[0] = -1f;
        }
    }

    public void BlastLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _blastTimers[1] = 0f;
        }

        if (context.canceled)
        {
            if (_blastTimers[1] > holdBlastTimer) //Blast Jump
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(new Vector2(100f * 7, 0f), ForceMode2D.Force);
            }
            else //Normal Jump
            {
                rb.AddForce(new Vector2(100f * 4, 0f), ForceMode2D.Force);
            }

            _blastTimers[1] = -1f;
        }
    }

    public void BlastRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _blastTimers[2] = 0f;
        }

        if (context.canceled)
        {
            if (_blastTimers[2] > holdBlastTimer) //Blast Jump
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(new Vector2(100f * -7, 0f), ForceMode2D.Force);
            }
            else //Normal Jump
            {
                rb.AddForce(new Vector2(100f * -4, 0f), ForceMode2D.Force);
            }

            _blastTimers[2] = -1f;
        }
    }

    public void BlastUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _blastTimers[3] = 0f;
        }

        if (context.canceled)
        {
            if (_blastTimers[3] > holdBlastTimer) //Blast Jump
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(new Vector2(0f, 100f * -7), ForceMode2D.Force);
            }
            else //Normal Jump
            {
                rb.AddForce(new Vector2(0f, 100f * -4), ForceMode2D.Force);
            }

            _blastTimers[3] = -1f;
        }
    }
}
