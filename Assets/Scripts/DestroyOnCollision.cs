using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float damageValue = -0.4f; // adjust as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Raindrop hit the ant!");
            GameManager.Instance.HealthUpdate(damageValue);
            Destroy(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }
}