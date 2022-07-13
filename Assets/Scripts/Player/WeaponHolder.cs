using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _weaponPrefab;
    [SerializeField] private string _weaponName;
    [SerializeField] protected List<Weapon> _instantiatedWeapons = new List<Weapon>();

    public string WeaponName => _weaponName;
    public string NextUpgradeDescription => _weaponData.NextUpgradeDescription;
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
        var prevCount = _weaponData?.Count ?? 0;
        _weaponData = _weaponPrefab.GetWeaponData(_context, _tier);
        var toSpawn = _weaponData.Count - prevCount;
        while (toSpawn > 0)
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

    protected abstract void UseWeapon();

    private IEnumerator UseBullet()
    {
        foreach (var weapon in _instantiatedWeapons)
        {
            weapon.UseWeapon(transform);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
