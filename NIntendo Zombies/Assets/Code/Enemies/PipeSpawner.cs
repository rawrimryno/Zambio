using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{

    public GameObject enemy1; // Enemy Prefab to spawn
    public int e1Count;
    public float e1Time, yForce, initY;
    public List<GameObject> enemyList;
    private Vector3 dy = Vector3.up;
    private Rigidbody enemyRB;

    void Awake()
    {

    }
    void Start()
    {
        InvokeRepeating("Spawn", e1Time, e1Time);
        if (yForce > 0)
        {
            yForce *= -1;
        }
        if (initY < 0)
        {
            initY = 1f;
            dy *= initY;
        }
    }


    void Spawn()
    {
        if (gameObject.CompareTag("UpPipe"))
        {
            dy *= -1;
        }
        Instantiate(enemy1, transform.position + dy, transform.rotation);
    }

    void OnColliderEnter(Collision cInfo)
    {
        if (cInfo.gameObject.CompareTag("Enemy"))
        {
            enemyRB = cInfo.gameObject.GetComponent<Rigidbody>();
        }

    }
    void OnColliderStay(Collision cInfo)
    {
        if (gameObject.CompareTag("UpPipe") && cInfo.gameObject.CompareTag("Enemy"))
        {
            yForce *= -1;
            enemyRB.AddForce(new Vector3(0, yForce, 0));


        }
    }
}

