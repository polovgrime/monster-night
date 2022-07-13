using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    [SerializeField] private int _expAmount = 5;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var playerExp = collider.GetComponent<PlayerExperience>();

        if (playerExp != null)
        {
            playerExp.ReceiveExperience(_expAmount);
            Destroy(gameObject);
        }
    }
}
