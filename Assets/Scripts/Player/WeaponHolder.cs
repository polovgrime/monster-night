using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _weaponPrefab;
    private WeaponContext _context;
    private int _tier;
    private WeaponData _weaponData;
    private float _actualCooldown = 10f;

    private void Start()
    {
        _context = WeaponContext.instance;
        _tier = 0;
        OnWeaponUpgraded();
    }

    public void OnWeaponUpgraded()
    {
        _tier++;
        _weaponData = _weaponPrefab.GetWeaponData(_context, _tier);
        _actualCooldown = 0;
    }

    private void FixedUpdate()
    {
        _actualCooldown -= Time.fixedDeltaTime;
        if (_actualCooldown <= float.Epsilon)
        {
            UseWeapon();
            _actualCooldown = _weaponData.Cooldown;
        }
    }

    private void UseWeapon()
    {
        for (int i = 0; i < _weaponData.Count; i++)
        {
            Instantiate(_weaponPrefab, transform.position, Quaternion.identity);
        }
    }
}
