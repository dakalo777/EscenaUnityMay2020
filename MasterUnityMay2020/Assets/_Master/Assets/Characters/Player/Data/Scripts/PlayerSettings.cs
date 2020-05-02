using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "Settings/Player")]
public class PlayerSettings : ScriptableObject
{
    [Header("Locomotion Settings")]
    [Range(0.1f, 10)]
    [SerializeField] private float maxSpeed = 3;
    [Range(0.1f, 2)]
    [SerializeField] private float stoppingDistance = 0.5f;
    [Range(1, 10)]
    [SerializeField] private float acceleration=8;
    [Range(10, 300)]
    [SerializeField] private float angularSpeed=120;

    [Header("Health Settings")]
    [Range(10, 500)]
    [SerializeField] private float maxHealth = 100;

    [Header("Aggro Settings")]
    [Range(1, 5)]
    [SerializeField] private float attackRange = 2f;

    [Header("Interaction Context")]
    [SerializeField] private LayerMask floorMask = new LayerMask { };
    [SerializeField] private LayerMask enemiesMask = new LayerMask { };


    public float MaxSpeed => maxSpeed;
    public float StoppingDistance => stoppingDistance;
    public float Acceleration => acceleration;
    public float AngularSpeed => angularSpeed;
    public float MaxHealth => maxHealth;
    public float AttackRange => attackRange;
    public LayerMask FloorMask => floorMask;
    public LayerMask EnemiesMask => enemiesMask;

}
