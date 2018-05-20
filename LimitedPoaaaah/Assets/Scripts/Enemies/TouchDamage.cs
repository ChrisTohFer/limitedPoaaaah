using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour {

    //Variables ~~~

    [Header("Properties")]
    public int _damage;

    //Audio
    private AudioSource Audio;

    private void Start()
    {
        Audio = GameObject.Find("Player Hit").GetComponent<AudioSource>();
    }

    //Triggers ~~~

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Audio.Play();
            PowerLevel targetPower = other.GetComponent<PowerLevel>();
            Debug.Log(targetPower.AddPower(_damage));
            gameObject.SetActive(false);
        }

        
    }

}
