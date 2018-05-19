using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script is automatically added to objects created by pool, and re-adds them when they are destroyed

public class PooledObject : MonoBehaviour {

    //References and variables ~~~

    ObjectPool _parentPool;
    public ObjectPool parentPool
    {
        set { _parentPool = value; }
    }

    //Triggers ~~~

    void OnDisable()
    {
        _parentPool.ReturnObject(gameObject);
    }
}
