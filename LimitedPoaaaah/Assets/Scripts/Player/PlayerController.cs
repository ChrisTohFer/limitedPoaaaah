using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed =20;
    void Update()
    {
        Vector3 movement;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed + transform.position.x;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed + transform.position.z;

       // movement = new Vector3(x, 0, z);
       // movement.Normalize()

        /**transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z); **/
        transform.position = new Vector3(x, transform.position.y, z);
    }
}