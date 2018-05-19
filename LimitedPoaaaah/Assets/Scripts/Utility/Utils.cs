using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static bool GroundRay(out Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            pos = hit.point;
            return true;
        }
        else
        {
            return false;
        }
    }
	
}
