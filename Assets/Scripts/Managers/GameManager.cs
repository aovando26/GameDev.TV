using StarterAssets;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameIsActive;
    public UnityEvent<float> OnHealthChanged = new UnityEvent<float>();
    public UnityEvent OnAntDied = new UnityEvent(); // New event
    public float health = 1.0f; // Normalized: 1.0 = full health, 0 = dead
    public bool antIsAlive = true;
    private string starterScene = "Starter";

    private float totalPickups = 0;

    public UnityEvent<float> OnFoodChanged = new UnityEvent<float>();
    public GameObject[] applePickups;

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

        if (health <= 0.1f && antIsAlive)
        {
            Debug.Log("Ant has died");
            antIsAlive = false;
            OnAntDied.Invoke();
            GameObject playerArmature = GameObject.Find("PlayerArmature");
            playerArmature.GetComponentInChildren<ThirdPersonController>().enabled = false;
            StartCoroutine(LoadSceneName());
        }
    }
    IEnumerator LoadSceneName()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(starterScene);
    }
    public void AddPickup()
    {
        totalPickups += 1f;
        OnFoodChanged.Invoke(totalPickups);
    }

    public float GetCurrentFood()
    {
        return totalPickups;
    }
}