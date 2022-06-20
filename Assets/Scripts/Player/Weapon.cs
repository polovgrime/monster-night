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
    protected Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {        
            enemy.ApplyDamage(_currentDamage);
            gameObject.SetActive(false);
        }
    }

    public abstract WeaponData GetWeaponData(WeaponContext context, int tier);

    public void UpdateWeaponParameters(WeaponData data)
    {
        _baseDamageOffset = data.DamageOffset;
        _durationMultiplyer = data.DurationMultiplyer;
    }

    public virtual void UseWeapon(Transform parent)
    {
        transform.position = parent.position;
        _rigidbody2D.velocity = Vector2.zero;
        Refresh();
    }

    protected abstract void Refresh();
}