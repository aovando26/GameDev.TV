using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string endScene = "EndScene";
        SceneManager.LoadScene(endScene);
    }
}
