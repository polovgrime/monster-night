using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpawner : Spawner
{
    [SerializeField] private GameObject _target;

    protected override void SetUpSpawn()
    {
        Spawn(_target);
    }
}
