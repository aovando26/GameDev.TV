using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject healthCanvas;
    public GameObject foodCanvas;

    [Header("Sliders")]
    public Slider healthSlider;
    public Slider foodSlider;

    private float initialHealth = 1.0f;
    private float initialFood = 0f;

    public GameObject deathCanvas;

    private void Start()
    {
        GameManager.Instance.OnHealthChanged.AddListener(UpdateHealthBar);
        GameManager.Instance.OnAntDied.AddListener(ShowDeathCanvas);
        GameManager.Instance.OnFoodChanged.AddListener(UpdateFoodBar);


        healthSlider.value = initialHealth;

        foodSlider.maxValue = 6; // Match required pickups
        foodSlider.value = initialFood;

        deathCanvas.SetActive(false);
    }

    private void UpdateHealthBar(float health)
    {
        healthSlider.value = Mathf.Clamp01(health);
    }

    private void UpdateFoodBar(float foodCount)
    {
        foodSlider.value = foodCount;
    }

    private void ShowDeathCanvas()
    {
        deathCanvas.SetActive(true);
    }
}