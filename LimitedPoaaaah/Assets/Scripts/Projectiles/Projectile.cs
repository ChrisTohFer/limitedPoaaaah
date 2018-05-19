using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class controls firing and movement of projectiles

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    //Variables and references ~~~

    //Properties ~~~
    [Header("Properties")]
    public float _speed;
    public float _lifeTime;

    //References
    public Rigidbody _rb;

    //Initialisation ~~~

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //Update ~~~

    private void FixedUpdate()
    {
        _lifeTime -= Time.fixedDeltaTime;
        if (_lifeTime <= 0f)
            gameObject.SetActive(false);
    }

    //Methods ~~~

    public void Fire(Vector3 target, Vector3 source, float range, float speed)
    {
        transform.position = source;
        transform.LookAt(target);

        _rb.velocity = (target - source).normalized * speed;
        _lifeTime = range / speed;
    }

}
