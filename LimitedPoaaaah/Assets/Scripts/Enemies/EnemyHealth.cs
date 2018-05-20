using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    //References and variables ~~~

    //Properties
    [Header("Properties")]
    public float _maxHealth = 2;
    float _health;

    //Audio
    private AudioSource Audio;

    //Initialisation ~~~

    void Start()
    {
        _health = _maxHealth;
        Audio = GameObject.Find("Enemy Death").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        _health = _maxHealth;
        Audio = GameObject.Find("Enemy Death").GetComponent<AudioSource>();
    }

    //Methods ~~~

    //Apply damage
    public void Damage(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
        {
            Audio.Play();
            KillCounter.kc.IncrementCounter();


            gameObject.SetActive(false);
        }
    }

}
