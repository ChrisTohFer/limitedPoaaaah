using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTarget : MonoBehaviour {

    public static Transform _player;

	// Use this for initialization
	void Start () {
        _player = transform;
	}
}
