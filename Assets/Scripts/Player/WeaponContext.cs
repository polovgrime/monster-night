
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponContext : MonoBehaviour
{
    public static WeaponContext instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<WeaponData> Swords = new List<WeaponData>()
    {
        new WeaponData(1, 1, 1, 2, 0, "+1 projectile, lower cooldown"),
        new WeaponData(2, 1, 2, 1.75f, 0, "tba"),
        new WeaponData(3, 1, 3, 1.75f, 0, "tba"),
        new WeaponData(4, 1, 4, 1.75f, 0, "tba"),
        new WeaponData(5, 1, 5, 1.55f, 0, "tba"),
        new WeaponData(6, 1, 10, 1.25f, 0, "tba"),
    };

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }   
    }
}

public class WeaponData
{
    public readonly int Tier;

    public readonly float DamageMultiplyer;

    public readonly float DurationMultiplyer;

    public readonly int Count;

    public readonly int DamageOffset;

    public readonly float Cooldown;

    public string NextUpgradeDescription;

    public WeaponData(int tier, float durMultiplyer, int count, float cooldown, int damageOffset, string nextUpgradeDescription)
    {
        Tier = tier;
        DurationMultiplyer = durMultiplyer;
        Count = count;
        DamageOffset = damageOffset;
        Cooldown = cooldown;
        NextUpgradeDescription = nextUpgradeDescription;
    }
}

