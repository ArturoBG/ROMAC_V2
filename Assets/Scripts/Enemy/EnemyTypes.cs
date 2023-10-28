using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Arsenal/EnemyType")]
public class EnemyTypes : ScriptableObject
{
    public int Health;
    public int MovementSpeed;
    public int TimerOfDamage;

}
