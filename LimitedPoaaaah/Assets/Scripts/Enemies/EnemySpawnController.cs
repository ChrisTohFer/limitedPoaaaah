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
            _chargeEnemyCooldown = _chargeEnemySpawnTime;
            _spawner.SquareSpawn(EnemySpawner.EnemyType.CHARGE_ENEMY, Vector3.zero, 40f, 40f);
        }
        else
        {
            _chargeEnemyCooldown -= Time.fixedDeltaTime;
        }

	}
}
