using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public string weaponName;
    public int damage;
    [SerializeField]
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
        //col.isTrigger = false;
    }

    public void TurnOnCollider()
    {
        Debug.Log("TUrn on collider ");
        col.isTrigger = true;
    }

    public void TurnOffCollider()
    {
        col.isTrigger = false;
    }
}