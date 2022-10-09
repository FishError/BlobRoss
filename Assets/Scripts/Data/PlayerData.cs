using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Health")]
    public float HealthPoints = 100f;

    [Header("Attack")]
    public float Attack = 5f;
    public float AttackSpeed = 1f;

    [Header("Defense")]
    public float Defense = 5f;

    [Header("Move State")]
    public float MovementVelocity = 5f;
}
