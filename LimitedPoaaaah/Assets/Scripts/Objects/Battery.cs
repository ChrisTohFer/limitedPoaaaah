using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

	//Properties ~~~

    [Header("Properties")]
    public int _energy = 4;

    //Triggers ~~~

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PowerLevel>().AddPower(_energy);
            transform.parent.gameObject.SetActive(false);
        }
    }

}
