using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private List<GameObject> _weak;
    protected override void SetUpSpawn()
    {
        Spawn(_weak[Random.Range(0, _weak.Count)]);
    }
}
