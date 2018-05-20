using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    //Variables and references ~~~

    //References
    [Header("Component References")]
    public EnemySpawner _spawner;

    //Variables
    public float _chargeEnemySpawnTime = 5;
    public float _spawnTimeReduction = 0.95f;
    float _chargeEnemyCooldown;

    //Initialisation ~~~

    void Start()
    {
        _chargeEnemyCooldown = _chargeEnemySpawnTime;
    }

    //Update ~~~

    void FixedUpdate () {
		if(_chargeEnemyCooldown < 0f)
        { 
            _chargeEnemyCooldown = _chargeEnemySpawnTime = _chargeEnemySpawnTime * _spawnTimeReduction;
            _spawner.CircleSpawn(EnemySpawner.EnemyType.CHARGE_ENEMY, Vector3.zero, 20f);
            if (Random.value > 0.8f)
                _spawner._chargeEnemyPool._max++;
        }
        else
        {
            _chargeEnemyCooldown -= Time.fixedDeltaTime;
        }

	}
}
