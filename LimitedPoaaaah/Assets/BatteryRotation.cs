using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotation : MonoBehaviour {

    public GameObject Battery;

    public float RotationSpeed = 1;
	
	// Update is called once per frame
	void FixedUpdate () {

        Battery.transform.Rotate(0, RotationSpeed, 0);
		
	}
}
