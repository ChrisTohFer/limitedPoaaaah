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
    public float _leftBound;
    public float _rightBound;
    public float _topBound;
    public float _bottomBound;
    public float _trailDistance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
