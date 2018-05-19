using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour {

    //Variables ~~~

    [Header("Properties")]
    public int _damage;

    //Triggers ~~~

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PowerLevel targetPower = other.GetComponent<PowerLevel>();
            Debug.Log(targetPower.AddPower(_damage));
        }

        gameObject.SetActive(false);
    }

}
