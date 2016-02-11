using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour {

    public GameObject enemy1; // Enemy Prefab to spawn
    public int e1Count;
    public float e1Time, yForce;
    public List<GameObject> enemyList;

    private Rigidbody enemyRB;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", e1Time, e1Time);
        if ( yForce > 0)
        {
            yForce *= -1;
        }
	}
	
	// Update is called once per frame
	void Spawn () {
        Vector3 dy = new Vector3 (0,-1,0);
        if (gameObject.CompareTag("UpPipe"))
        {
            dy *= -2;
        }
        Instantiate(enemy1, transform.position+dy, transform.rotation);
	}

    void OnTriggerStay( Collider other )
    {
        if (other.CompareTag("Enemy")){
            enemyRB = other.GetComponent<Rigidbody>();
            if(gameObject.CompareTag("UpPipe"))
            {
                yForce *= -1;
                enemyRB.AddForce(new Vector3(0, yForce, 0));
            }
        }
    }
}
