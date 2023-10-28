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

    public float threeQuartersHealth;

    public void SetTotalHealth(int value)
    {
        totalHealth = value;
    }

    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;
        totalHealth -= damage;
        if (totalHealth < 0)
        {
            totalHealth = characterHealth;
        }
        CheckColor();
    }

    public void HealUp(int value)
    {
        healthBar.value += value;
        totalHealth += value;
        if (totalHealth > characterHealth)
        {
            totalHealth = characterHealth;
        }
        CheckColor();
    }

    public void InitHealth()
    {
        totalHealth = characterHealth;        
        healthBar.maxValue = characterHealth;
        healthBar.value = characterHealth;
        fillBar.color = maxHealth;
    }

    private void CheckColor()
    {
        //basandonos en que el personaje tiene 100HP
        if (healthBar.value >= 75)//75%
        {
            fillBar.color = maxHealth;
        }
        else if (healthBar.value >= 50 && healthBar.value <= 74)
        {
            fillBar.color = midHealth;
        }
        else if (healthBar.value > 0 && healthBar.value <= 49)
        {
            fillBar.color = critHealth;
        }
    }
}

