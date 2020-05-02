using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public static PlayerBrain Instance;

    [SerializeField] private PlayerSettings settings = null;
    public PlayerSettings Settings => settings;

    #region Logic Controllers
    public bool IsActive { get; private set; }
    public float CurrentSpeed;
    public bool hasEnemyTarget { get; private set; }
    private GameObject enemy;
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);

        IsActive = true;
    }

    private void Update()
    {
        if (hasEnemyTarget)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) <= settings.AttackRange)
            {
                print("Enemy Reached");
                EventsManager.Instance.BroadcastEnemyInRange();
            }
        }
    }
    public void MoveCommand(Vector3 point)
    {
        if (IsActive)
        {
            EventsManager.Instance.BroadcastMoveCommand(point);
        }
    }

    public void DestinationReached()
    {

    }

    public void EnemySelected(GameObject enemy)
    {
        if (IsActive)
        {
            hasEnemyTarget = true;
            this.enemy = enemy;
            print("Enemyfound");
        }
    }
}


