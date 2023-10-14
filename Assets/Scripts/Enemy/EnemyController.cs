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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("weapons"))
        {
            Debug.Log(this.name + "Trigger Entered " + other.name);
            int damageReceived = other.GetComponent<WeaponScript>().damage;
            healthComponent.TakeDamage(damageReceived);            
        }
        
    }

}
