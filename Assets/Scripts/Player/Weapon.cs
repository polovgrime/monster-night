using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _tier;
    protected float _currentDamage => _damage * GameParameters.GetMultiplier(GameParameters.DamageMultiplier);
    public int Tier => _tier;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Попал по врагу");
        var enemy = collision.GetComponent<Enemy>();
        enemy.ApplyDamage(_currentDamage);
        Destroy(gameObject);
    }
}
