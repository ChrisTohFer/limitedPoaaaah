using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class is responsible for player basic attack

public class BasicAttack : MonoBehaviour {

    //Variables and references ~~~

    //References
    [Header("References")]
    public ObjectPool _ammo;

    //Properties
    [Header("Properties")]
    public float _damage = 1f;
    public float _projectileSpeed = 20f;
    public float _range = 10f;
    public float _cooldown = 1f;

    //Variables
    float _timer;

    //Initialisation ~~~

    void Start()
    {
        _timer = _cooldown;
    }

    //Update ~~~

    void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && _timer <= 0f)
        {
            Vector3 position;
            if(Utils.GroundRay(out position))
            {
                GameObject proj = _ammo.Take();
                Projectile p = proj.GetComponent<Projectile>();
                p.Fire(new Vector3(position.x, transform.position.y, position.z), transform.position, _range, _projectileSpeed);
                _timer = _cooldown;
            }
        }

        if (_timer > 0f)
            _timer -= Time.fixedDeltaTime;
    }

}
