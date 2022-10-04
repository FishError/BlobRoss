using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 5f;

    [Header("Current Gear Equipped")]
    public GameObject redGear;
    public GameObject blueGear;
    public GameObject yellowGear;

    public void OnEnable()
    {
        redGear = GameObject.FindGameObjectWithTag("Weapon");
    }
}
