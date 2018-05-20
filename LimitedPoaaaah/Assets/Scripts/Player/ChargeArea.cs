using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArea : MonoBehaviour {

    public List<EnemyHealth> _contained;
    
    public void Activate(float damage)
    {
        for(int i = 0; i < _contained.Count; ++i)
        {
            EnemyHealth eh = _contained[i];
            if(eh != null)
            {
                eh.Damage(damage);
            }
        }

        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            _contained.Add(other.GetComponent<EnemyHealth>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            _contained.Remove(other.GetComponent<EnemyHealth>());
        }
    }

}
