using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EatingBehavior : MonoBehaviour
{
    public float eatingSpeed = 0.2f;
    [SerializeField] private LayerMask edibleLayer;
    private CharacterController charController;
    private GameObject foodTarget;

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
            Eat(foodTarget);
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
            foodTarget = null;
        }
    }
}