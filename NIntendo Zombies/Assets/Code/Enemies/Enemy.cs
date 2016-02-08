using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private GameControllerSingleton gc;
    private Collider mCollider;
    private Rigidbody rb;

    private bool hasExited=false;
    private bool needsUp = false;

    public float dY;


	// Use this for initialization
	void Start () {
        gc = GameControllerSingleton.get();
        mCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        if (dY < 0)
            dY = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if ( !hasExited )
        {
            mCollider.isTrigger = false;
        }
        if ( needsUp )
        {
            transform.position = new Vector3(0, transform.position.y + dY, 0);
        }
	}

    void onTriggerEnter( Collider other )
    {
        if(other.CompareTag("UpPipe"))
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
    }

}
