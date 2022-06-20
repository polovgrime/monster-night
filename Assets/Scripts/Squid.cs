using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb2d;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _renderer.flipX = Player.PlayerInstance.transform.position.x > transform.position.x;

        if(Vector2.Distance(transform.position, Player.PlayerInstance.transform.position) < 5)
        {
            _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        } else 
            _rb2d.constraints = RigidbodyConstraints2D.None;
    }
}
