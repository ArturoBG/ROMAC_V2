using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private Image fillBar;

    [SerializeField]
    private int characterHealth; //HP character, static

    [SerializeField]
    private int totalHealth; // dynamic, HP restante

    [SerializeField]
    private Color maxHealth;

    [SerializeField]
    private Color midHealth;

    [SerializeField]
    private Color critHealth;


    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;
        totalHealth -= damage;
        if (totalHealth < 0)
        {
            totalHealth = characterHealth;
        }

    }

    public void HealUp(int value)
    {
        healthBar.value += value;
        totalHealth += value;
        if (totalHealth > characterHealth)
        {
            totalHealth = characterHealth;
        }
    }

    public void ResetHealth()
    {
        totalHealth = characterHealth;        
        healthBar.maxValue = characterHealth;
        healthBar.value = characterHealth;
    }



}

