using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] string _weaponName;
    [SerializeField] private List<Weapon> _weapons;
    private float _cooldown;
    public string WeaponName => _weaponName;


}
