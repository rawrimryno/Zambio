using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
    private Rigidbody rb;
//    private GameControllerSingleton gameController;
    private float initY, currY;
    public float initTorque = 40;
    public float initYForce = 5;
    public float k = 3;

	// Use this for initialization
	void Start () {
//        gameController = GameControllerSingleton.get();
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeTorque(0, initTorque, 0);
        rb.AddRelativeForce(0, initYForce, 0);
        initY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

	}

    // FixedUpdate called at standard time intervals, good for physics
    void FixedUpdate()
    {
        currY = transform.position.y;
        rb.AddRelativeForce(0, -(currY - initY) * k, 0);
    }

    void OnCollisionExit(Collision cInfo)
    {
        if (cInfo.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    
}
