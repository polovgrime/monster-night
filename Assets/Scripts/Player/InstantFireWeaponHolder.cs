using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantFireWeaponHolder : WeaponHolder
{ 
    protected override void UseWeapon()
    {
        _instantiatedWeapons.ForEach(e => e.UseWeapon(transform));
    }
}
