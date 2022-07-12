using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player PlayerInstance => instance;

    [SerializeField] private int _baseHealth;
    [SerializeField] private List<WeaponHolder> _weapons;
    ParticleSystem _bloodEffect;
    private int _health;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
            return;
        }

        _health = _baseHealth;

        if (_weapons.Count != 0)
        {
            _weapons = _weapons
                .Select(e => SetUpWeapon(e))
                .ToList();
        }
    }

    private void Start()
    {
        _bloodEffect = GetComponent<ParticleSystem>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _bloodEffect.Play();
        if (_health < 0)
        {
            StartCoroutine(ApplyDeath());
        }
    }

    private IEnumerator ApplyDeath()
    {
        enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var weaponPickup = collider.GetComponent<WeaponPickupItem>();
        if (weaponPickup != null)
        {
            ApplyWeapon(weaponPickup.GetWeapon());
            Destroy(collider.gameObject);
        }
    }

    private void ApplyWeapon(WeaponHolder weaponHolder)
    {
        var existingWeapon = _weapons.FirstOrDefault(e => e.WeaponName == weaponHolder.WeaponName);

        if (existingWeapon == null)
        {
            _weapons.Add(SetUpWeapon(weaponHolder));
        }
        else 
        {
            existingWeapon.OnWeaponUpgraded();
        }
    }

    private WeaponHolder SetUpWeapon(WeaponHolder holder)
    {
        return Instantiate(holder, transform.position, Quaternion.identity, transform);
    }
}
