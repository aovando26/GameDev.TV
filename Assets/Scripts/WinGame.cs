using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
