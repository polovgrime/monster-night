using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    private float _currentSpeed;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentSpeed = _baseSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnSpeedChange(float additionalSpeed)
    {
        _currentSpeed += additionalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _direction.Normalize();
        _rigidBody.velocity = _direction * _currentSpeed;
        if (_rigidBody.velocity.x != 0)
            _spriteRenderer.flipX = _rigidBody.velocity.x < 0;
    }
}
