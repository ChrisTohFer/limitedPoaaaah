using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //
    public Transform _tracks;
    public float speed =20;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Quaternion rotation = Quaternion.Euler(new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f));
        Vector3 movement =  rotation * new Vector3(x, 0f, z);

        _tracks.eulerAngles = new Vector3(0f, Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z), 0f);

        /**transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z); **/
        transform.position = transform.position + movement;
    }
}