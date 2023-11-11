using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyTypes enemySO;
    public EnemyMovement enemyMovement;
    private int health;
    private HealthScript healthComponent;
    public float timerOfDamage;
    private PlayerWeapons playerWeapons;

    [SerializeField]
    private bool IsDamageReceived = false;

    // Start is called before the first frame update
    private void Start()
    {
        //References
        playerWeapons = GetComponent<PlayerWeapons>();
        enemyMovement.animator = GetComponent<Animator>();
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
        timerOfDamage = enemySO.TimerOfDamage;
        enemyMovement.agent.speed = enemySO.MovementSpeed;
    }

    private void Update()
    {
        if (enemyMovement.enemyCombat.IsAtDistance)
        {
            transform.LookAt(enemyMovement.playerTransform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the collider is a weapon AND we can take damage again
        if (other.tag.Equals("weapons") && !IsDamageReceived)
        {
            Debug.Log("Weapon entered");
            StartCoroutine(DamageTakenRoutine(other));
        }
    }

    private IEnumerator DamageTakenRoutine(Collider other)
    {
        //Debug.Log("Sword did damage");
        IsDamageReceived = true;
        int damageReceived = other.GetComponent<WeaponScript>().weaponDamage;
        healthComponent.TakeDamage(damageReceived);
        enemyMovement.animator.SetTrigger("damage");
        yield return new WaitForSeconds(timerOfDamage);
       // Debug.Log("damage done all set");
        IsDamageReceived = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.3f);
    }

}