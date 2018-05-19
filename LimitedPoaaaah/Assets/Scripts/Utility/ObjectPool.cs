using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class pools objects created from the prefab up to a maximum
//PooledObject is attached to the spawned objects so that they readd themselves to the pool

public class ObjectPool : MonoBehaviour {

    //Required Variables and References ~~~

    //Inspector settings
    [Header("Pool Settings")]
    public GameObject _prefab;
    public int _startCount = 0;
    public int _max = 1;

    //Private variables
    Queue<GameObject> _pool;
    int _objectCount = 0;

    //Initialisation ~~~

	//Spawn in initial objects
	void Start () {
        _pool = new Queue<GameObject>();

        for (int i = _objectCount; i < _startCount; ++i)
        {
            CreateAndPoolObject();
        }
	}
	
	//Update ~~~

    //Methods ~~~

    //Create new GameObject
    GameObject CreateObject()
    {
        GameObject go = Instantiate(_prefab);
        PooledObject po = go.AddComponent<PooledObject>();
        po.parentPool = this;
        
        ++_objectCount;
        return go;
    }
    //Create and pool
    void CreateAndPoolObject()
    {
        GameObject go = CreateObject();
        go.SetActive(false);

        _pool.Enqueue(go);
    }

    //Readd object to pool
    public void ReturnObject(GameObject go)
    {
        _pool.Enqueue(go);
    }

    /// <summary>
    /// Takes an object from the pool. Returns null if maximum objects are active.
    /// </summary>
    /// <returns></returns>
    public GameObject Take()
    {
        GameObject go = null;
        if (_pool.Count > 0)
        {
            go = _pool.Dequeue();
        }
        else if(_objectCount < _max)
        {
            go = CreateObject();
        }

        if(go != null)
            go.SetActive(true);
        return go;
    }
}
