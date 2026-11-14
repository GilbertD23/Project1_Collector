using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    public WeaponData weapon;

    void Start()
    {
        GetComponent<Renderer>().material.color = weapon.tint;
        Debug.Log(weapon.weaponName + " deals " + weapon.damage + " damage.");
    }
}