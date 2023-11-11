using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Arsenal/EnemyType")]
public class EnemyTypes : ScriptableObject
{
    public int Health;
    public float MovementSpeed;
    public int TimerOfDamage;

}
