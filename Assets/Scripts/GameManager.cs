using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameIsActive;
    public UnityEvent<float> OnHealthChanged = new UnityEvent<float>();
    public float health = 1.0f; // Normalized: 1.0 = full health, 0 = dead

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void HealthUpdate(float valueDelta)
    {
        health = Mathf.Clamp01(health + valueDelta);
        OnHealthChanged.Invoke(health);
    }
}