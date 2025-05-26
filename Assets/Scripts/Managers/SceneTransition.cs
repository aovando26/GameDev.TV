using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

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
        string starterScene = "Starter";
        string starterSound = "Starter Sound";
        string mainSound = "Main Sound";

        string mainScene = "Main";  
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
    }

    private void OnDestroy()
    {
        // Unregister the callback when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
