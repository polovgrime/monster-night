using System.Linq;
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField] private float _baseSpeed = 5;
    [SerializeField] private float _speedPerTier = 1.25f;
    private int _tier = 0;
    private PlayerMovement _playerMovement;

    protected override void Refresh()
    {   
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);
        
        if (_playerMovement == null)
        {
            _playerMovement = Player.PlayerInstance
                .GetComponent<PlayerMovement>();
        }

        _rigidbody2D.velocity = _playerMovement
            .LastDirection * (_baseSpeed + _speedPerTier * _tier);
    }

    private void Start()
    {
        Refresh();
    }

    public override WeaponData GetWeaponData(WeaponContext context, int tier)
    {
        var descriptor = context.Bullets.Where(e => e.Tier == tier).FirstOrDefault();
        if (descriptor == null)
        {
            descriptor = context
                .Bullets
                .OrderByDescending(e => e.Tier)
                .First();
        }

        _tier = tier;

        return descriptor;
    }
}
