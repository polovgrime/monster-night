using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer;
    [SerializeField] private float _spawnOffset;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _maxDistanceFromPlayer = 20;

    private float _timeRemaining;
    private Transform _playerTransform;
    private List<GameObject> _spawnedEntities = new List<GameObject>();

    private void Start()
    {
        _timeRemaining = _spawnCooldown;
        _playerTransform = Player.PlayerInstance.transform;
        StartCoroutine(KillAfterTime());
        StartCoroutine(RelocateEntities());
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
        _spawnedEntities.Add(Instantiate(target, GetNewSpawnLocation(), Quaternion.identity, transform));
    }

    private Vector2 GetNewSpawnLocation()
    {
        var direction = Vector2.zero;
        while (direction == Vector2.zero)
        {
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
        direction.Normalize();

        var magnitude = Random.Range(_distanceFromPlayer, _distanceFromPlayer + _spawnOffset);
        var relativePoint = direction * magnitude;

        return (Vector2)_playerTransform.position + relativePoint;
    }

    private IEnumerator KillAfterTime()
    {
        yield return new WaitForSeconds(_destroyTime * 60);
        Destroy(gameObject);
    }
    
    private IEnumerator RelocateEntities()
    {
        yield return new WaitForSeconds(4);
        foreach (var targetGameObject in _spawnedEntities.Where(e => Vector2.Distance(_playerTransform.position, e.transform.position) > _maxDistanceFromPlayer))
        {
            targetGameObject.transform.position = GetNewSpawnLocation();
        }
        StartCoroutine(RelocateEntities());
    }

    protected abstract void SetUpSpawn();

    public void RemoveEntity(GameObject obj)
    {
        _spawnedEntities.Remove(obj);
    }
}