using UnityEngine;

public class WeaponPickupItem : MonoBehaviour
{
    [SerializeField] private WeaponHolder _weapon;

    public WeaponHolder GetWeapon()
    {
        return _weapon;
    }
}