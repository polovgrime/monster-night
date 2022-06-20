using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sword : Weapon
{
    protected override void Refresh()
    {   
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);
        _rigidbody2D.AddForce(500 * new Vector2(Random.Range(-1f, 1f), 1));
    }

    public override WeaponData GetWeaponData(WeaponContext context, int tier)
    {
        var descriptor = context.Swords.Where(e => e.Tier == tier).FirstOrDefault();
        if (descriptor == null)
        {
            descriptor = context
                .Swords
                .OrderByDescending(e => e.Tier)
                .First();
        }
        return descriptor;
    }

    
}
