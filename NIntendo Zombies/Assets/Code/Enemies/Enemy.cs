using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private GameControllerSingleton gc;
    private Collider myCollider;
    private Rigidbody rb;

    private bool hasExited=false;
    public bool needsUp = false;

    public float yForce, dY, rotScal;


	// Use this for initialization
	void Start () {
        gc = GameControllerSingleton.get();
        myCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        if (dY < 0)
            dY = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if ( !hasExited )
        {
            myCollider.isTrigger = false;
        }
	}

    void onTriggerEnter( Collider other )
    {
        if (other.CompareTag("UpPipe"))
        {
            needsUp = true;
        }
    }

    void onTriggerExit( Collider other)
    {
        if (other.CompareTag("UpPipe"))
        {
            needsUp = false;
        }
        hasExited = true;
        //myCollider.isTrigger = true;
    }

}
