using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _weaponPrefab;
    [SerializeField] private string _weaponName;
    public string WeaponName => _weaponName;
    public string NextUpgradeDescription => _weaponData.NextUpgradeDescription;
    private WeaponContext _context;
    private int _tier;
    private WeaponData _weaponData;
    private float _actualCooldown = 10f;

    [SerializeField]private List<Weapon> _instantiatedWeapons = new List<Weapon>();

    private void Start()
    {
        _context = WeaponContext.instance;
        _tier = 0;
        OnWeaponUpgraded();
    }

    public void OnWeaponUpgraded()
    {
        _tier++;
        var prevCount = _weaponData?.Count ?? 0;
        _weaponData = _weaponPrefab.GetWeaponData(_context, _tier);
        var toSpawn = _weaponData.Count - prevCount;
        while(toSpawn > 0)
        {
            var position = _instantiatedWeapons.FirstOrDefault()?.transform.position ?? transform.position;
            var weapon = Instantiate(_weaponPrefab, position, Quaternion.identity);
            _instantiatedWeapons.Add(weapon);
            toSpawn--;
        }

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
        _instantiatedWeapons.ForEach(e => e.UseWeapon(transform));
        // for (int i = 0; i < _weaponData.Count; i++)
        // {
        //     Instantiate(_weaponPrefab, transform.position, Quaternion.identity);
        // }
    }
}
