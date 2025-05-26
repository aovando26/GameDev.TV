using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.Play("Raindrop");
        Destroy(gameObject, .5f);
    }
}