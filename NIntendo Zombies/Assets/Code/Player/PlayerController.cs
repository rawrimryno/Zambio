using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private GameControllerSingleton gc;

    private List<GameControllerSingleton.PowerUp> PowerUps;

    private bool hasFire, hasJump;

    [SerializeField]
    public float forwardScalar, jumpScalar, turnSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
        gc = GameControllerSingleton.get();
        if (forwardScalar <= 0)
        {
            forwardScalar = 3;
        }
        if (jumpScalar <= 0)
        {
            jumpScalar = 3;
        }
        PowerUps = new List<GameControllerSingleton.PowerUp>();
	}

    // Update is called once per frame
    void Update() {
        if ( rb.angularVelocity.magnitude < 0.2)
        {
            rb.angularVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(forwardScalar * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-forwardScalar * Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Math.Abs(rb.velocity.y) < 0.1)
            {
                rb.AddForce( (hasJump ? 2 : 1) * jumpScalar * Vector3.up);
            }
        }
	}

    void OnCollisionEnter( Collision cInfo )
    {
        if ( gc.isPowerUp(cInfo.collider) )
        {
            gc.tempPowerUp = gc.getPowerUp(cInfo.collider.tag);
            PowerUps.Add(gc.tempPowerUp);
            setPowerUp(gc.tempPowerUp);
            gc.tempPowerUp.Id = -1; // Not valid
        }
    }

    void setPowerUp( GameControllerSingleton.PowerUp check)
    {
        switch( check.Id ) {
            case 1:
                hasFire = true; break;
            case 2:
                hasJump = true; break;
            default:
                Debug.Log("SetPowerUp Found something weird."); break;
        }
    }
}
