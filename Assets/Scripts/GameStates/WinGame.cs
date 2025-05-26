using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour
{
    public string endScene = "EndScene";
    public int requiredPickups = 6;

    private bool readyToDetect = false;
    private void Start()
    {
        StartCoroutine(EnableDetectionAfterDelay());
    }

    private IEnumerator EnableDetectionAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        readyToDetect = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!readyToDetect) return;

        if (other.CompareTag("Player"))
        {
            float currentFood = GameManager.Instance.GetCurrentFood();

            if (currentFood >= requiredPickups)
            {
                Debug.Log("Player collected all pickups. Loading EndScene...");
                SceneTransition.Instance.LoadScene(endScene);
            }
            else
            {
                Debug.Log("Not enough pickups yet!");
            }
        }
    }
}
