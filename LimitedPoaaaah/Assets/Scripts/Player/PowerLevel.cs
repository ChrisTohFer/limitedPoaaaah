using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class keeps track of the power level of the player/enemy

public class PowerLevel : MonoBehaviour {

    //Variables and references ~~~

    //Properties
    [Header("Properties")]
    public int _startPower = 5;
    public int _maxPower = 10;

    //Variables
    int _power;
    public int Power
    {
        get { return _power; }
    }

    //Initialisation ~~~

    void Start()
    {
        _power = _startPower;
    }

    //Methods ~~~

    //Add energy to total (also subtract for negative)
    //Returns the energy proportion (1 for max, 0 for none, >1 for overfilled)
    public float AddPower(int power)
    {
        _power += power;

        return (float)_power / (float)_maxPower;
    }
}
