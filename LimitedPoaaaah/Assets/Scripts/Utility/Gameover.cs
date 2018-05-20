using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {

    public float _timeToReset;
	
	// Update is called once per frame
	void Update () {
		if(!GlobalTarget._player.gameObject.activeSelf)
        {
            _timeToReset -= Time.deltaTime;
            if(_timeToReset < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
