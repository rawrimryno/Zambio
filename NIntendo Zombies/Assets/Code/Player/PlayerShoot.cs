using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public Rigidbody projectile;
    public float bulletSpeed;

	// Use this for initialization
	void Start () {
	    if (bulletSpeed == 0)
        {
            bulletSpeed = 20.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        }
	}
}
