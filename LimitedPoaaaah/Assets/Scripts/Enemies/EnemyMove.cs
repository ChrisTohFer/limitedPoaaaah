using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Class provides enemy movement functionality

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour {

    //Variables and references ~~~

    //Properties
    [Header("Properties")]
    public float _speed = 1f;
    public float _angularSpeed = 360f;
    public float _acceleration = 10f;

    [Header("Pathfinding")]
    public float _pathUpdateTime = 1f;
    public float _updateRandomTime = 0.1f;
    public float _destinationOffset = 0.2f;

    //References
    NavMeshAgent _agent;
    Transform _target;

    //Variables
    float _checkCooldown = 0f;

    //Initialisation ~~~

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    //Update ~~~

    void FixedUpdate () {
		if(_checkCooldown <= 0f)
        {
            //Randomise check timer slightly
            _checkCooldown = _pathUpdateTime + 2.0f * (Random.value - 0.5f) * _updateRandomTime;
            SetDestination(GlobalTarget._player.position);
        }
        else
        {
            _checkCooldown -= Time.fixedDeltaTime;
        }
	}

    //Methods ~~~

    public void SetDestination(Vector3 destination)
    {
        float x = Random.value - 0.5f;
        float y = Random.value - 0.5f;
        Vector3 offset = new Vector3(x, 0f, y).normalized * _destinationOffset * Random.value;

        _agent.SetDestination(destination + offset);
    }

}
