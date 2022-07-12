using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer;
    [SerializeField] private float _spawnOffset;
    // Start is called before the first frame update
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _destroyTime;
    private float _timeRemaining;

    private void Start()
    {
        _timeRemaining = _spawnCooldown;
        StartCoroutine(KillAfterTime());
    }

    private void Update()
    {
        if (_timeRemaining <= 0)
        {
            _timeRemaining = _spawnCooldown;
            SetUpSpawn();
        }

        _timeRemaining -= Time.deltaTime;
    }

    protected virtual void Spawn(GameObject target)
    {
        var direction = Vector2.zero;
        while(direction == Vector2.zero)
        { 
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
        direction.Normalize();

        var magnitude = Random.Range(_distanceFromPlayer, _distanceFromPlayer +  _spawnOffset);
        var relativePoint = direction * magnitude;
        var playerTransform = Player.PlayerInstance.transform;

        Instantiate(target, (Vector2)playerTransform.position + relativePoint, Quaternion.identity, playerTransform.parent);
    }

    private IEnumerator KillAfterTime()
    {
        yield return new WaitForSeconds(_destroyTime * 60);
        Destroy(gameObject);
    }


    protected abstract void SetUpSpawn();
}
