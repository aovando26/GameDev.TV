using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public GameObject healthCanvas;
    public Slider healthSlider;
    private float initialHealth = 1.0f;

    private void Start()
    {
        GameManager.Instance.OnHealthChanged.AddListener(UpdateHealthBar);
        healthSlider.value = initialHealth;
    }

    private void UpdateHealthBar(float health)
    {
        healthSlider.value = Mathf.Clamp01(health);
    }
}