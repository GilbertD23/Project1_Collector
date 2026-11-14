using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public WeaponData weapon;
    private Ammo ammo;

    void Start()
    {
        ammo = new Ammo(weapon.magazineSize);
        ammo.Emptied += OnEmptied;
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.spaceKey.wasPressedThisFrame)
        {
            if (ammo.TryFire())
            {
                Debug.Log("Fired " + weapon.weaponName + " for " + weapon.damage + " damage. Ammo: " + ammo.Current + "/" + ammo.Max);
            }
            else
            {
                Debug.Log("Click. " + weapon.weaponName + " is empty.");
            }
        }

        if (kb.rKey.wasPressedThisFrame)
        {
            ammo.Reload();
            Debug.Log("Reloaded " + weapon.weaponName + ".");
        }
    }

    void OnEmptied()
    {
        Debug.Log(weapon.weaponName + " magazine empty.");
    }
}