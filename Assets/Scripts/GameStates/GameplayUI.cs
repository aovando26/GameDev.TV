using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public GameObject healthCanvas;
    public Slider healthSlider;
    private float initialHealth = 1.0f;

    public GameObject deathCanvas;

    private void Start()
    {
        GameManager.Instance.OnHealthChanged.AddListener(UpdateHealthBar);
        GameManager.Instance.OnAntDied.AddListener(ShowDeathCanvas);
        healthSlider.value = initialHealth;
        deathCanvas.SetActive(false);
    }

    private void UpdateHealthBar(float health)
    {
        healthSlider.value = Mathf.Clamp01(health);
    }

    private void ShowDeathCanvas()
    {
        deathCanvas.SetActive(true);
    }
}