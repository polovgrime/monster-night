using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private float _experienceScaler = 2;
    [SerializeField] private float _experienceMultiplier = 1;
    private float _currentExperience = 0;
    [SerializeField] private float _nextExperienceCeiling = 5;
    private int _currentLevel = 0;

    public void ReceiveExperience(float amount)
    {
        var addedExp = amount * _experienceMultiplier;

        _currentExperience += addedExp;

        if (_currentExperience >= _nextExperienceCeiling)
        {
            var addNextExp = _currentExperience - _nextExperienceCeiling;
            _nextExperienceCeiling *= _experienceScaler;
            _currentLevel++;
            _currentExperience = 0;
            Debug.Log("Reached new level! " + _currentLevel);
            if (addedExp > 1)
            {
                ReceiveExperience(addNextExp);
            }
        }
    }  
}
