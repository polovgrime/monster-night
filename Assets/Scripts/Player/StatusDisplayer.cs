using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDisplayer : MonoBehaviour
{
    private GameObject _player;
    // Start is called before the first frame update
    private void OnHealthChanged(float current, float max)
    {
        Debug.Log($"Player's health: {current} out of {max}");
    }

    private void OnExpChanged(float current, float max)
    {
        Debug.Log($"Player's exp: {current} out of {max}");
    }

    private void Start()
    {
        var _playerInstance = Player.PlayerInstance;
        _player = _playerInstance.gameObject;
        var playerHealth = _playerInstance.GetComponent<PlayerHealth>();
        playerHealth.HealthChanged += OnHealthChanged;
        var playerExperience = _playerInstance.GetComponent<PlayerExperience>();
        playerExperience.ExpChanged += OnExpChanged;
    }
}
