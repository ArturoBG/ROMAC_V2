using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public WeaponScript[] weapon;

    public void TurnOnWeapon()
    {
        weapon[0].turnOnCollider();
    }

    public void TurnOffWeapon()
    {
        weapon[0].turnOffCollider();
    }
}
