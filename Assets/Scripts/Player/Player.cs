using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player PlayerInstance => instance;

    [SerializeField] private int _baseHealth;
    ParticleSystem _bloodEffect;
    private int _health;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        _health = _baseHealth;
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
}
