using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AntBehavior : MonoBehaviour
{
    public float eatingSpeed = 0.2f;
    [SerializeField] private LayerMask edibleLayer;
    private CharacterController charController;
    private GameObject foodTarget;
    private float pointValue = 0.1f;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (foodTarget == null)
        {
            Collider[] edibles = Physics.OverlapSphere(transform.position, 0.1f, edibleLayer);
            if (edibles.Length > 0)
            {
                foodTarget = edibles[0].gameObject;
            }
        }

        if (foodTarget != null && Input.GetKey(KeyCode.E))
        {
            Sound eatSound = Array.Find(AudioManager.Instance.sounds, s => s.name == "Anteating");

            if (eatSound != null && !eatSound.source.isPlaying)
            {
                AudioManager.Instance.Play("Anteating");
            }

            Eat(foodTarget);
        }

        // Stop sound when key is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            AudioManager.Instance.Stop("Anteating");
        }
    }

    private void Eat(GameObject target)
    {
        if (target == null) return;

        target.transform.localScale = Vector3.Lerp(
            target.transform.localScale,
            Vector3.zero,
            Time.deltaTime * eatingSpeed
        );

        if (target.transform.localScale.magnitude < 90f)
        {
            Destroy(target);
            GameManager.Instance.HealthUpdate(pointValue);
            foodTarget = null;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        float deductHealth = -0.2f;

        if (collider.gameObject.CompareTag("Raindrop"))
        {
            Debug.Log("Animal hit");
            GameManager.Instance.HealthUpdate(deductHealth);
        }

        if (collider.gameObject.CompareTag("Pickup"))
        {
            Destroy(collider.gameObject);
            GameManager.Instance.AddPickup();
            Debug.Log("Ant has pickup: " + GameManager.Instance.GetCurrentFood());
        }
    }
}