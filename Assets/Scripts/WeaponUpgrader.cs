using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponUpgrader : MonoBehaviour
{
    public static WeaponUpgrader instance { get; private set; }
    private Dictionary<string, WeaponHolder> _weapons { get; set; }
    private Dictionary<string, WeaponHolder> _availableWeapons { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowUpgrades()
    {
        Debug.Log(string.Join("\n", _weapons.Select(e => e.Key)));
    }

    public void AddWeapon(WeaponHolder weapon)
    {
        this._weapons.Add(weapon.WeaponName, weapon);
    }
}
