using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event PlayerStatusChangeHandler HealthChanged;
    private ParticleSystem _bloodEffect;
    [SerializeField] private int _baseHealth;

    private int _health;

    private void Awake()
    {
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
        HealthChanged(_health, _baseHealth);
        
        if (_health < 0)
        {
            StartCoroutine(ApplyDeath());
        }
    }

    private IEnumerator ApplyDeath()
    {
        enabled = false;
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
