using UnityEngine;

public class GirlBehavior : MonoBehaviour
{
    private Animator m_Animator;
    public GameObject antPosition;

    private float stompCooldown = 1f;  // delay between stomps
    private float stompTimer = 0f;

    private bool isStomping = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, antPosition.transform.position);

        if (distance < 3f)
        {
            isStomping = true;
            stompTimer += Time.deltaTime;

            if (stompTimer >= stompCooldown)
            {
                Debug.Log("Stomp triggered");
                m_Animator.SetBool("isStomping", true);
                stompTimer = 0f;
            }
        }
        else
        {
            if (isStomping)
            {
                Debug.Log("Stopped stomping");
                m_Animator.SetBool("isStomping", false);
            }

            isStomping = false;
            stompTimer = stompCooldown;
        }
    }
}
