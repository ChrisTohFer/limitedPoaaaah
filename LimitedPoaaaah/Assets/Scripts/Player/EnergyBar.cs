using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

    //Variables and references ~~~
    public Image[] _healthBars;
    
    //Methods ~~~

    //Update bars based on health
    public void UpdateEnergy(int energy)
    {
        for(int i = 0; i < _healthBars.Length; ++i)
        {
            _healthBars[i].gameObject.SetActive(i < energy);
        }
    }

}
