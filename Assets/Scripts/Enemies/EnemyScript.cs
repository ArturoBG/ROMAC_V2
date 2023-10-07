using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    HealthScript healthScript;

    [SerializeField]
    float timer = 5f;

    [SerializeField]
    Animator animator;

    public bool damageTaken = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Weapon") && !damageTaken)
        {
            StartCoroutine(damageReceived(other));
        }
       
    }

    IEnumerator damageReceived(Collider other)
    {
        damageTaken = true;
        Debug.Log("Damage taken");
        animator.SetTrigger("damage");
        healthScript.TakeDamage(other.GetComponent<WeaponScript>().weaponDamage);
        yield return new WaitForSeconds(timer);
        damageTaken = false;
    }
}
