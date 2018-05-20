using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class controls the camera movement; camera will follow the followtarget

public class CameraControl : MonoBehaviour {

    //Variables and references ~~~

    //Properties
    [Header("Properties")]
    public float _leftBound = 0f;
    public float _rightBound = 10f;
    public float _topBound = 10f;
    public float _bottomBound = 0f;
    public float _trailDistance = 1f;
    public float _speed = 5f;
    public float _camHeight = 10f;
    public float _orthographicHeight = 10f;
    float _minSpeed;
    Vector3 _offset;

    //Initialisation ~~~

    void Start()
    {
        _minSpeed = _speed / 2.0f;
        float angle = Mathf.Deg2Rad * Camera.main.transform.eulerAngles.x;
        float rotation = Mathf.Deg2Rad * Camera.main.transform.eulerAngles.y;
        float radius = _camHeight / Mathf.Tan(angle);
        float x = -radius * Mathf.Sin(rotation);
        float z = -radius * Mathf.Cos(rotation);
        _offset = new Vector3(x, _camHeight, z);

        Camera.main.orthographicSize = _orthographicHeight / 2f;
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
        Vector3 targetPos = GlobalTarget._player.position + _offset;
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
