using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("Technical Settings")]
    [SerializeField] private int framesPerSecond;


    [Header("Gameplay Settings")]
    [SerializeField] private float totalGameTime;
    private float totalGameTimeTimer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("DLE - Found more than one Game Manager in the scene.");
        }
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = framesPerSecond;

        totalGameTimeTimer = totalGameTime;
    }

    private void FixedUpdate()
    {
        totalGameTimeTimer -= Time.fixedDeltaTime;

        if (totalGameTimeTimer <= 0)
        {
            Debug.Log("TIME IS UP");
        }
    }
}
