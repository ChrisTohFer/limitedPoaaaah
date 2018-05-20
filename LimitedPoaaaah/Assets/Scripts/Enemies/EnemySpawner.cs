using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class spawns enemies in a random position

public class EnemySpawner : MonoBehaviour {

    //Types ~~~

    public enum EnemyType
    {
        CHARGE_ENEMY,
        BATTERY
    }

    //Variables and references ~~~

    //Pool references
    [Header("Pool references")]
    public ObjectPool _chargeEnemyPool;
    public ObjectPool _batteryPool;

	// Use this for initialization
	void Start () {
		
	}

    //Methods ~~~

    //Spawn enemy of type type at position, return null if none left
    public GameObject Spawn(EnemyType type, Vector3 position)
    {
        GameObject g = null;
        switch (type)
        {
            case EnemyType.CHARGE_ENEMY:
                g = _chargeEnemyPool.Take();
                break;
            case EnemyType.BATTERY:
                g = _batteryPool.Take();
                break;
        }

        if (g != null)
        {
            g.SetActive(true);
            g.transform.position = position;
        }

        return g;
    }

    //Spawn randomly somewhere in a square
    public GameObject SquareSpawn(EnemyType type, Vector3 center, float width, float height)
    {
        float x = width * Random.value + center.x - width / 2.0f;
        float y = height * Random.value + center.y - height / 2.0f;

        Vector3 pos = new Vector3(x, 0f, y);
        if ((pos - GlobalTarget._player.position).magnitude < 5f)
        {
            //If too close to player, call self to get new position
            return SquareSpawn(type, center, width, height);
        }
        else
        {
            return Spawn(type, new Vector3(x, 0f, y));
        }
        
    }
    //Spawn randomly in a circle
    public GameObject CircleSpawn(EnemyType type, Vector3 center, float radius)
    {
        Vector2 position = radius * Random.insideUnitCircle;
        Vector3 spawnPos = center + new Vector3(position.x, 0f, position.y);

        return Spawn(type, spawnPos);
    }
}
