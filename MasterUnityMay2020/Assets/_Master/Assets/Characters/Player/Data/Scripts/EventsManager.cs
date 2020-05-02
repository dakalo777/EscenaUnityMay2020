using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;
    
    public static Action<Vector3> OnMovmentCommand = delegate { };
    public static Action OnEnemyInRange = delegate { };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    public void BroadcastMoveCommand(Vector3 point)
    {
        OnMovmentCommand(point);
    }

    public void BroadcastEnemyInRange()
    {
        OnEnemyInRange();
    }

}
