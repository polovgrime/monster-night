using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Lightning : Weapon
{
    // Start is called before the first frame update
    private Vector2 _target;
    private bool _isMoving;

    void Start()
    {
        EngageAttack();
    }

    protected override void Refresh()
    {
        _rigidbody2D.freezeRotation = false;
        transform.position = new Vector3(transform.position.x + Random.Range(-.75f, .75f), transform.position.y + Random.Range(-.75f, .75f), transform.position.z);
        gameObject.SetActive(true);
        EngageAttack();    
    }

    private void EngageAttack()
    {
        var closestEnemy = FindClosestEnemy();
        var diff = closestEnemy - (Vector2)transform.position;
        diff.Normalize();

        var rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90);
        _target = closestEnemy - (Vector2)transform.position;
        _target.Normalize();
        _target = _target * 1000;

        _isMoving = true;
        _rigidbody2D.freezeRotation = true;
    }

    private Vector2 FindClosestEnemy()
    {
        var raycastHit = Physics2D.CircleCast(transform.position, 20f, Vector2.zero, 20f, LayerMask.GetMask("Enemy"));
        return raycastHit.collider?.transform.position ?? Vector2.up;
    }

    public override WeaponData GetWeaponData(WeaponContext context, int tier)
    {
        var descriptor = context.Swords.Where(e => e.Tier == tier).FirstOrDefault();
        if (descriptor == null)
        {
            descriptor = context
                .Swords
                .OrderByDescending(e => e.Tier)
                .First();
        }
        return descriptor;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, _target, Time.fixedDeltaTime * 10));
        }
    }
}
