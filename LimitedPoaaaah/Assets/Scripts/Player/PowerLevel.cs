using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class keeps track of the power level of the player/enemy

public class PowerLevel : MonoBehaviour {

    //Variables and references ~~~

    //References
    [Header("References")]
    public EnergyBar _bar;

    //Properties
    [Header("Properties")]
    public int _startPower = 5;
    public int _maxPower = 10;

    [Header("Stats")]
    public float _minSpeed = 5f;
    public float _maxSpeed = 10f;

    public float _minFireRate = 1f; float _maxFireTime;
    public float _maxFireRate = 4f; float _minFireTime;

    //Variables
    int _power;
    public int Power
    {
        get { return _power; }
    }
    bool _kill = false;
    public bool Kill
    {
        get { return _kill; }
    }

    //Initialisation ~~~

    void Start()
    {
        _power = _startPower;

        _maxFireTime = 1.0f / _minFireRate;
        _minFireTime = 1.0f / _maxFireRate;

        AdjustSettings();
    }

    //Methods ~~~

    public float Fraction()
    {
        return (float)_power / (float)_maxPower;
    }
    public void AdjustSettings()
    {
        _bar.UpdateEnergy(Mathf.Min(_maxPower, _power));

        float fraction = Fraction();

        BasicAttack ba = GetComponent<BasicAttack>();
        PlayerController pc = GetComponent<PlayerController>();

        ba._cooldown = Mathf.Lerp(_maxFireTime, _minFireTime, fraction);
        pc.speed = Mathf.Lerp(_minSpeed, _maxSpeed, fraction);
    }

    //Add energy to total (also subtract for negative)
    //Returns the energy proportion (1 for max, 0 for none, >1 for overfilled)
    public float AddPower(int power)
    {
        _power += power;
        if (_power > _maxPower)
            _power = _maxPower;
        if (_power < 0)
        {
            _power = 0;
            _kill = true;
        }

        AdjustSettings();

        return Fraction();
    }
}
