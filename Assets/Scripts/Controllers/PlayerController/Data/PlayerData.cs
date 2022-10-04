using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 5f;

    [Header("Current Weapon")]
    public GameObject currentWeapon;

    public void OnEnable()
    {
        currentWeapon = GameObject.FindGameObjectWithTag("Weapon");
    }
}
