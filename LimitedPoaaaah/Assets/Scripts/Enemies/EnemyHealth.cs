using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    //References and variables ~~~

    //Properties
    [Header("Properties")]
    public float _maxHealth;
    float _health;

    //Initialisation ~~~

    void Start()
    {
        _health = _maxHealth; 
    }
    void OnEnable()
    {
        _health = _maxHealth;
    }

    //Methods ~~~

    //Apply damage
    public void Damage(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
        {
            KillCounter.kc.IncrementCounter();


            gameObject.SetActive(false);
        }
    }

}
