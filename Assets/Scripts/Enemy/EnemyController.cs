using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyTypes enemySO;

    private int health;
    private float speed;
    private HealthScript healthComponent;
    private Animator animator;
    public float timerOfDamage;
    private PlayerWeapons playerWeapons;

    [SerializeField]
    private bool IsDamageReceived = false;

    // Start is called before the first frame update
    private void Start()
    {
        //References
        playerWeapons = GetComponent<PlayerWeapons>();
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthScript>();

        //Init components
        AssingSOVariables();
        
        //health
        healthComponent.SetTotalHealth(health);
        healthComponent.InitHealth();

        
    }

    private void AssingSOVariables()
    {
        health = enemySO.Health;
        speed = enemySO.MovementSpeed;
        timerOfDamage = enemySO.TimerOfDamage;
    }


    private void OnTriggerEnter(Collider other)
    {
        //if the collider is a weapon AND we can take damage again
        if (other.tag.Equals("weapons") && !IsDamageReceived)
        {
            StartCoroutine(DamageTakenRoutine(other));
        }
    }

    private IEnumerator DamageTakenRoutine(Collider other)
    {
        //Debug.Log("Sword did damage");
        IsDamageReceived = true;
        int damageReceived = other.GetComponent<WeaponScript>().damage;
        healthComponent.TakeDamage(damageReceived);
        animator.SetTrigger("damage");
        yield return new WaitForSeconds(timerOfDamage);
       // Debug.Log("damage done all set");
        IsDamageReceived = false;
    }
}