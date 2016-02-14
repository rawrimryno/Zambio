using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private GameControllerSingleton gc;
    public Inventory myInv;
    public TextAsset FirstSaveFile;

    //                <powerup.alias, true/false>
    private Dictionary<string, bool> hasPowerUp;

    public float moveSpeed, jumpScalar, turnSpeed, superJumpMult;

    void Awake()
    {
        hasPowerUp = new Dictionary<string, bool>();
        rb = GetComponent<Rigidbody>();
        gc = GameControllerSingleton.get();
        myInv = GetComponent<Inventory>();
    }
	// Use this for initialization
	void Start () {

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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gc.SaveState( FirstSaveFile, this );
        }
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




    // Checks to see if the value is already in the dictionary with TryGetValue
    // Then Adds it if it is not.
    public void setPowerUp(GameControllerSingleton.PowerUp check)
    {
        bool val;
        if (!hasPowerUp.TryGetValue(check.alias, out val))
        {
            hasPowerUp.Add(check.alias, true);
        }
    }

    // Uses the dictionary remove method to remove our AppliedPowerUp
    public bool removePowerUp(string name)
    {
        return hasPowerUp.Remove(name);
    }

    // Check to see if a player has a powerup,
    // targetPC - Player to check, self for player script is attached to
    //          -                ; expandable for multiplayer =D
    // returns if the player has the powerup in their hasPowerUp Dictionary
    public bool plrHasPowerUp( PlayerController targetPC, string name )
    {
        bool val;
        return hasPowerUp.TryGetValue(name, out val);
    }

}
