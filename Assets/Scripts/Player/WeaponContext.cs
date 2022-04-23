
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponContext : MonoBehaviour 
{
    public static WeaponContext instance;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<WeaponTierDescriptor<Sword>> Swords = new List<WeaponTierDescriptor<Sword>>()
    {
        new WeaponTierDescriptor<Sword>(1, 1, 1, 1, 2, 0)
    };
}

public class WeaponTierDescriptor<T> 
    where T : Weapon
{
    public readonly int Tier;
    
    public readonly float DamageMultiplyer;
    
    public readonly float DurationMultiplyer;
    
    public readonly int Count;

    public readonly int DamageOffset;

    public readonly float Cooldown;

    public WeaponTierDescriptor(int tier, float dmgMultiplyer, float durMultiplyer, int count, float cooldown, int damageOffset)
    {
        Tier = tier;
        DamageMultiplyer = dmgMultiplyer;
        DurationMultiplyer = durMultiplyer;
        Count = count;
        DamageOffset = damageOffset;
        Cooldown = cooldown;
    }
}

