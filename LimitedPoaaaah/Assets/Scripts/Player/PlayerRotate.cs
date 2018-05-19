using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{

    private Vector3 mousePos;
    private float lastAngle;
    void Update()
    {
        Vector3 position;
        if (Utils.GroundRay(out position))
        {

         //   mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.z - transform.position.z));
            transform.LookAt(position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
