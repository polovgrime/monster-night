using System.Collections;
using System.Linq;
using UnityEngine;

public class BurstFireWeaponHolder : WeaponHolder
{
    // Start is called before the first frame update
    [SerializeField] private float _burstPause = 0.25f;
    protected override void UseWeapon()
    {
        StartCoroutine(UseBurst());
    }


    private IEnumerator UseBurst()
    {
        
        foreach (var weapon in _instantiatedWeapons.OrderBy(e => e.gameObject.activeSelf).Take(_weaponData.Count))
        {
            weapon.UseWeapon(transform);
            yield return new WaitForSeconds(_burstPause);
        }
    }
}
