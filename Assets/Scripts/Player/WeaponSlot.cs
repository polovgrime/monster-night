using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSlot : MonoBehaviour
{
    protected List<Weapon> _weapons;
    protected Weapon _currentWeapon;
    protected int _currentTear = 0;

    public void UpgradeWeapon()
    {

    }

    public abstract void UseWeapon();
}
