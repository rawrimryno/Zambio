using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Inventory : MonoBehaviour
{
    private GameControllerSingleton gc;
    private PlayerController pc;

    [Serializable]
    public class ammo
    {
        public int greenShells { get; set; }
        public int redShells { get; set; }
        public int blueShells { get; set; }
        public int bulletBills { get; set; }
        public int redBulletBills { get; set; }
    }

    public class contents
    {
        public ammo myAmmo
        {
            get; private set;
        }

        public List<GameControllerSingleton.PowerUp> PowerUps;

        public contents()
        {
            PowerUps = new List<GameControllerSingleton.PowerUp>();
        }
        
       public void powerUpSave(TextAsset saveFile)
        {
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision cInfo)
    {
        GameControllerSingleton.PowerUp cPowerUp;
        if (gc.isPowerUp(cInfo.collider))
        {
            cPowerUp = gc.getPowerUp(cInfo.collider.tag);

            // Player already has the powerup applied to them
            if ( pc.plrHasPowerUp( cPowerUp.alias ) )
            {
                myContents.PowerUps.Add(cPowerUp);
            }
            // Player does not, apply it!
            else
            {
                pc.setPowerUp(cPowerUp);
            }
        }
    }
    
    // saveContents handles the call from the Game Controller to save InventoryContents
    // This is powerups in inventory only, not ammo, and not currently applied powerups
    public void saveContents(TextAsset saveFile)
    {

    }

}
