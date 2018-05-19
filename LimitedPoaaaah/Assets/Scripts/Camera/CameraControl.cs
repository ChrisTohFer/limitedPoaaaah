using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class controls the camera movement; camera will follow the followtarget

public class CameraControl : MonoBehaviour {

    //Variables and references ~~~

    //References
    [Header("References")]
    public Transform _followTarget;

    //Properties
    [Header("Properties")]
    public float _leftBound = 0f;
    public float _rightBound = 10f;
    public float _topBound = 10f;
    public float _bottomBound = 0f;
    public float _trailDistance = 1f;
    public float _speed = 5f;
    public float _camHeight = 10f;
    float _minSpeed;
    float _angle;
    Vector3 _offset;

    //Initialisation ~~~

    void Start()
    {
        _minSpeed = _speed / 2.0f;
        _angle = Mathf.Deg2Rad * Camera.main.transform.eulerAngles.x;
        _offset = new Vector3(0f, _camHeight, -_camHeight * Mathf.Tan(_angle));
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetSpeedToPlayer()
    {
        //TODO: Set max speed to player speed
        //player p = _followTarget.gameObject.GetComponent<player>();
        //SetSpeed(p.speed);
    }

    //Update ~~~
	
	void Update () {

        //Calculate the displacement and distance between camera and target
        Vector3 targetPos = _followTarget.position + _offset;
        Vector3 displacement = targetPos - transform.position;
        float distance = displacement.magnitude;

        //Calculate speed and movement vector
        float speed = Mathf.Lerp(_minSpeed, _speed, distance / _trailDistance);
        Vector3 movement = displacement.normalized * speed * Time.deltaTime;

        //If movement vector is larget than distance between target and camera then set position to target
        if(movement.magnitude > distance)
        {
            transform.position = targetPos;
        }
        else
        {
            transform.position += movement;
        }

        //TODO: Add boundary constraints
	}
}
