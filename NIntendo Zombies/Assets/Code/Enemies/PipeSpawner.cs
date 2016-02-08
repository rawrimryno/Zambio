using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour {

    public GameObject enemy1; // Enemy Prefab to spawn
    public int e1Count;
    public float e1Time;
    public List<GameObject> enemyList;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", e1Time, e1Time);
	}
	
	// Update is called once per frame
	void Spawn () {
        Instantiate(enemy1, transform.position, transform.rotation);
	}
}
