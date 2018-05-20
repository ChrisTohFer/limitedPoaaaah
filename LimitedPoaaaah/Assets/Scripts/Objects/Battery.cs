using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

	//Properties ~~~

    [Header("Properties")]
    public int _energy = 4;

    //Audio
    private AudioSource Audio;

    private void Start()
    {
        Audio = GameObject.Find("Collect Energy").GetComponent<AudioSource>();
    }


    //Triggers ~~~

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Audio.Play();
            other.GetComponent<PowerLevel>().AddPower(_energy);
            transform.parent.gameObject.SetActive(false);
        }
    }

}
