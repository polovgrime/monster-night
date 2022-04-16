using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameParameters
{
    public const string DamageMultiplier = "DamageMultiplier";
    public const string PlayerHealthMultiplier = "HealthMultiplier";

    private static GameParameters _instance;
    private Paremeter<float> _multiplier = new Paremeter<float>(1);
    public static float GetMultiplier(string name)
    {
        return _instance._multiplier.Get(name);
    }

    public static void Initialize()
    {
        if (_instance == null) _instance = new GameParameters();
    }

    public static void Destroy()
    {
        _instance = null;
    }

    private class Paremeter<T>
    {
        private Dictionary<string, T> _values = new Dictionary<string, T>();
        private T _defaultValue;
        public Paremeter(T defaultValue)
        {
            _defaultValue = defaultValue;
        }
        public T Get(string name)
        {
            return _values.ContainsKey(name) ? _values[name] : _defaultValue;
        }

        public void Set(string name, T value)
        {
            _values.Add(name, value);
        }
    }
}
