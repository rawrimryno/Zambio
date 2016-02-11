using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private GameControllerSingleton gc;
    private Inventory myInv;

    private Dictionary<string, bool> hasPowerUp;

    public float moveSpeed, jumpScalar, turnSpeed, superJumpMult;

    void Awake()
    {
        hasPowerUp = new Dictionary<string, bool>();
    }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
        gc = GameControllerSingleton.get();
        myInv = GetComponent<Inventory>();
        if (moveSpeed <= 0)
        {
            moveSpeed = 3;
        }
        if (jumpScalar <= 0)
        {
            jumpScalar = 3;
        }
	}

    // Update is called once per frame
    void Update() {

	}

    void FixedUpdate()
    {
        if (rb.angularVelocity.magnitude < 0.2)
        {
            rb.angularVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(moveSpeed * Vector3.forward);
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
            rb.AddForce(-moveSpeed * Vector3.forward);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (Math.Abs(rb.velocity.y) < 0.1)
            {
                rb.AddForce((hasPowerUp.ContainsKey("SuperJump") ? superJumpMult : 1) * jumpScalar * Vector3.up);
            }
        }
    }

    public void setPowerUp(GameControllerSingleton.PowerUp check)
    {
        hasPowerUp.Add(check.alias, true);
    }
    public bool removePowerUp(string name)
    {
        return hasPowerUp.Remove(name);
    }

}
