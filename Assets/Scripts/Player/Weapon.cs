using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    private float _damageMultiplyer;
    private float _durationMultiplyer;
    private int _baseDamageOffset;
    protected float _currentDamage => _damage * GameParameters.GetMultiplier(GameParameters.DamageMultiplier);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {        
            enemy.ApplyDamage(_currentDamage);
            Destroy(gameObject);
        }
    }

    public abstract WeaponData GetWeaponData(WeaponContext context, int tier);
    public void UpdateWeaponParameters(WeaponData data)
    {
        _baseDamageOffset = data.DamageOffset;
        _damageMultiplyer = data.DamageMultiplyer;
        _durationMultiplyer = data.DurationMultiplyer;
    }
}

public class WeaponData
{
    public int Tier;

    public float DamageMultiplyer;

    public float DurationMultiplyer;

    public int Count;

    public int DamageOffset;

    public float Cooldown;
}