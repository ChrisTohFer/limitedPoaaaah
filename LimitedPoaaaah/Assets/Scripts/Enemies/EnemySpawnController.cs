using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour {

    //Variables and references ~~~

    //References
    [Header("Component References")]
    public EnemySpawner _spawner;
    public ObjectPool _enemyPool;
    public Text _waveCounter;
    public Text _waveTimer;

    //Properties
    [Header("Properties")]
    public float _enemiesPerWave = 10;
    public float _enemiesFlatIncrease = 0f;
    public float _enemiesProportionalIncrease = 1.5f;
    public float _waveDuration = 10.0f;
    public float _durationFlatIncrease = 0f;
    public float _durationProportionalIncrease = 1.2f;
    public float _breakTime = 3.0f;

    //Other settings
    [Header("Other settings")]
    public float _mapSizeX = 40f;
    public float _mapSizeY = 40f;

    //Variables
    float _duration;
    float _count;
    float _amplitude;

    float _enemyPotential = 0f;
    public float _timer = 0f;
    private int _wave = 0;

    //Initialisation ~~~

    void Start()
    {
        _duration = _waveDuration;
        _count = _enemiesPerWave;
        CalculateAmplitude();
    }
    //Calculate the function amplitude constant
    void CalculateAmplitude()
    {
        _amplitude = _count * 2.0f / _duration;
    }

    //Update ~~~

    void FixedUpdate () {
        //For positive times, wave is active
        if(_timer >= 0f)
        {
            _enemyPotential += WaveFunction();
            while(_enemyPotential >= 1.0f)
            {
                _enemyPotential -= 1f;
                _spawner.SquareSpawn(EnemySpawner.EnemyType.CHARGE_ENEMY, Vector3.zero, _mapSizeX, _mapSizeY);
            }

            if(_timer >= _duration)
            {
                _duration *= _durationProportionalIncrease;
                _duration += _durationFlatIncrease;
                _count *= _enemiesProportionalIncrease;
                _count += _enemiesFlatIncrease;

                _enemyPool._max = (int)(_count * _enemiesProportionalIncrease);
                CalculateAmplitude();

                _timer = -_breakTime;
                _wave++;
            }
        }

        UpdateUI();
        _timer += Time.fixedDeltaTime;

	}

    //Methods ~~~

    float WaveFunction()
    {
        return _amplitude * Mathf.Pow(Mathf.Sin(Mathf.PI * _timer / _duration), 2.0f) * Time.fixedDeltaTime * 1.01f;
    }
    void UpdateUI()
    {
        _waveTimer.text = "Wave Timer: " + (int)_timer;
        _waveCounter.text = "Wave: " + _wave;
    }
}
