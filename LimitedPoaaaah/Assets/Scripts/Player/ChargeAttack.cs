using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour {

    //Variables and references ~~~

    //References
    public Transform _chargeCube;
    public Transform _bodyTrans;
    public ChargeArea _chargeArea;

    //Properties
    [Header("Properties")]
    public float _minLength = 1f;
    public float _maxLength = 5f;
    public float _minWidth = 0.3f;
    public float _maxWidth = 2f;
    public float _minDamage = 2f;
    public float _maxDamage = 4f;
    public float _minEnergyCost = 1f;
    public float _maxEnergyCost = 3f;
    public float _chargeTime = 2f;
    public float _coolDown = 1f;

    //Variables
    float _length;
    float _width;
    float _damage;
    float _cost;
    float _timer;

    bool _charging = false;

    //Initialisation ~~~

    void Start()
    {
        _timer = 0f;
    }

    // Update is called once per frame
    void FixedUpdate () {
		if(_timer <= 0f)
        {
            if(Input.GetMouseButtonDown(1))
            {
                _charging = true;
                _chargeCube.gameObject.SetActive(true);
            }
            if(Input.GetMouseButton(0))
            {
                _charging = false;
                _timer = 0f;
                _chargeCube.gameObject.SetActive(false);
            }
            if(_charging)
            {
                _timer -= Time.deltaTime;
                SetProperties();

                if(Input.GetMouseButtonUp(1))
                {
                    _charging = false;
                    _timer = _coolDown;
                    _chargeArea.Activate(_damage);
                    GetComponent<PowerLevel>().AddPower(-Mathf.RoundToInt(_cost));
                }
            }
            
        }
        else
        {
            _timer -= Time.fixedDeltaTime;
            if(_timer <= 0)
            {
                _timer = 0;
            }
        }
	}

    //Methods ~~~

    void SetProperties()
    {
        float charge = -_timer / _chargeTime;
        _length = Mathf.Lerp(_minLength, _maxLength, charge);
        _width = Mathf.Lerp(_minWidth, _maxWidth, charge);
        _damage = Mathf.Lerp(_minDamage, _maxDamage, charge);
        _cost = Mathf.Lerp(_minEnergyCost, _maxEnergyCost, charge);

        Vector3 positionOffset = new Vector3(0f, 0.3f, -_length / 2f - 0.5f);
        _chargeCube.position = transform.position + Quaternion.Euler(0f, _bodyTrans.eulerAngles.y, 0f) * positionOffset;
        _chargeCube.rotation = Quaternion.Euler(0f, _bodyTrans.eulerAngles.y, 0f);
        _chargeCube.localScale = new Vector3(_width, 0.5f, _length);
    }
}
