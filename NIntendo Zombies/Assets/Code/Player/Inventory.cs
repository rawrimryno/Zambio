using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    private GameControllerSingleton gc;
    private PlayerController pc;

    public class ammo
    {
        public int greenShells, redShells, blueShells;
        public int bulletBills;
    }
    public class contents
    {
        public ammo myAmmo;
        public List<GameControllerSingleton.PowerUp> PowerUps;

        public contents()
        {
            PowerUps = new List<GameControllerSingleton.PowerUp>();
        }
    }
    public contents myContents;

    void Awake()
    {
        gc = GameControllerSingleton.get();
        pc = GetComponent<PlayerController>();
        myContents = new contents();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision cInfo)
    {
        if (gc.isPowerUp(cInfo.collider))
        {
            gc.tempPowerUp = gc.getPowerUp(cInfo.collider.tag);
            myContents.PowerUps.Add(gc.tempPowerUp);
            pc.setPowerUp(gc.tempPowerUp);
            gc.tempPowerUp.Id = -1; // Not valid
        }
    }

}
