using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

    private string starterScene = "Starter";
    private string mainScene = "Main";
    private string endScene = "EndScene";
    public void LoadScene(string name)
    { 
        SceneManager.LoadScene(name);
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        string starterSound = "Starter Sound";
        string mainSound = "Main Sound";

        if (scene.name == starterScene)
        {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.Play(starterSound);
        }

        else if (scene.name == mainScene)
        {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.Play(mainSound);
        }

        else if (scene.name == endScene)
        {
            StartCoroutine(RestartGame(5f));
        }
    }

    IEnumerator RestartGame(float delay)
    { 
        yield return new WaitForSeconds(delay);
        LoadScene(starterScene);
    }
    private void OnDestroy()
    {
        // Unregister the callback when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
