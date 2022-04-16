using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _health = 10f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private bool _isReady = true;
    private Collider2D _collider2D;
    private Collider2D _playerCollider;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player = Player.PlayerInstance;
        _playerCollider = _player.GetComponent<Collider2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _spriteRenderer.flipX = transform.position.x < _player.transform.position.x;
        _rigidbody.MovePosition(Vector2.MoveTowards(transform.position, _player.transform.position, Time.fixedDeltaTime * _speed));

        if (_isReady == true && _collider2D.IsTouching(_playerCollider))
        {
            _player.ApplyDamage(_damage);
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _isReady = false;

        yield return new WaitForSeconds(_attackCooldown);

        _isReady = true;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
