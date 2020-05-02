using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Motor : MonoBehaviour
{
    private NavMeshAgent agent;

    private Vector3 destination;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetupAgent();
    }
    private void SetupAgent()
    {
        agent.stoppingDistance = PlayerBrain.Instance.Settings.StoppingDistance;
        agent.speed = PlayerBrain.Instance.Settings.MaxSpeed;
        agent.angularSpeed = PlayerBrain.Instance.Settings.AngularSpeed;
        agent.acceleration = PlayerBrain.Instance.Settings.Acceleration;
    }
    private void OnEnable()
    {
        EventsManager.OnMovmentCommand += SetupNewDestination;
        EventsManager.OnEnemyInRange += StopAgent;
    }
    private void OnDisable()
    {
        EventsManager.OnMovmentCommand -= SetupNewDestination;
        EventsManager.OnEnemyInRange -= StopAgent;
    }
    private void FixedUpdate()
    {
        PlayerBrain.Instance.CurrentSpeed = agent.velocity.magnitude / agent.speed;

        if (Vector3.Distance(transform.position, destination) <= agent.stoppingDistance)
        {
            PlayerBrain.Instance.DestinationReached();
        }
        else
        {
            var direction = destination - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);
            if (Vector3.Dot(transform.forward.normalized, direction.normalized) < .65f)
            {
                agent.isStopped = true;
            }
            else
                agent.isStopped = false;            
        }      

    }
    private void SetupNewDestination(Vector3 point)
    {
        destination = point;
        agent.destination = destination;
    }

    private void StopAgent()
    {
        agent.SetDestination(transform.position);
        agent.isStopped = true;
    }
}
