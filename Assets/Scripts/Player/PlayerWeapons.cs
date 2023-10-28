using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public WeaponScript[] weapons;

    public void TurnOnWeapon()
    {
        weapons[0].TurnOnCollider();
    }

    public void TurnOffWeapon()
    {
        weapons[0].TurnOffCollider();
    }
}
