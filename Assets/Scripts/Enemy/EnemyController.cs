using UnityEngine;

public class EnemyController : MonoBehaviour
{
    HealthScript healthComponent;
    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthScript>();
        healthComponent.ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            healthComponent.TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            healthComponent.HealUp(10);
        }
    }
}
