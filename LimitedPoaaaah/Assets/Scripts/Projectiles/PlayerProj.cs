using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProj : MonoBehaviour {

    //Properties

    public float _damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.Damage(_damage);
            gameObject.SetActive(false);
        }
    }

}
