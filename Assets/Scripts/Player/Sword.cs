using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sword : Weapon
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(500 * new Vector2(Random.Range(-1f, 1f), 1));
    }

    public override WeaponData GetWeaponData(WeaponContext context, int tier)
    {
        var descriptor = context.Swords.Where(e => e.Tier == tier).FirstOrDefault();
        if (descriptor == null) return new WeaponData();
        return new WeaponData
        {
            Tier = descriptor.Tier,
            DamageOffset = descriptor.DamageOffset,
            Count = descriptor.Count,
            DamageMultiplyer = descriptor.DamageMultiplyer,
            DurationMultiplyer = descriptor.DurationMultiplyer,
            Cooldown = descriptor.Cooldown
        };
    }

}
