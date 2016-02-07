using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private GameControllerSingleton gc;

    private List<GameControllerSingleton.PowerUp> PowerUps;

    private GameControllerSingleton.PowerUp tempPowerUp;

    private bool hasFire, hasJump;

    public float forwardScalar, jumpScalar;

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
	void Update () {
	    if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forwardScalar * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forwardScalar * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-forwardScalar * Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-forwardScalar * Vector3.left);
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
        if (cInfo.collider.CompareTag("PowerUp"))
        {
            tempPowerUp = gc.getPowerUp(cInfo.gameObject.name);
            PowerUps.Add(tempPowerUp);
            setPowerUp(tempPowerUp);
            tempPowerUp.Id = -1; // Not valid
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
