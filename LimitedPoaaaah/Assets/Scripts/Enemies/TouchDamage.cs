using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour {

    //Variables ~~~

    [Header("Properties")]
    public float _damage;

    //Triggers ~~~

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Damage stuff
        }
    }

}
