using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {

    public Text _text;
    int killcount = 0;

    public static KillCounter kc;

    private void Start()
    {
        kc = this;
    }

    public void IncrementCounter()
    {
        killcount += 1;
        _text.text = "Kill Count: " + killcount;
    }
}
