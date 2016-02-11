using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameControllerSingleton : ScriptableObject
{
    private static GameControllerSingleton Instance;

    public struct PowerUp
    {
        public Sprite sp;
        public string alias;
        public int Id;
        public string desc;
    }

    private Dictionary<string, PowerUp> powerUpDict;

    public static GameControllerSingleton get()
    {
        if (Instance == null)
        {
            Instance = ScriptableObject.CreateInstance<GameControllerSingleton>();
            Instance.Start();
        }

        return Instance;
    }

    // Public tempPowerUp for use throughout.  Set to -1 when done
    public PowerUp tempPowerUp;

    // Use this for initialization 
    public void Start() { 

        powerUpDict = new Dictionary<string, PowerUp>();
    }

    // Update is called once per frame
    // Main Game Logic Flow, Coroutine to do time dependent things.
    public void Update()
    {


    }

    public void loadPowerUps( TextAsset powerUpFile )
    {
        string alias, desc;
        int id;
        StringReader sr = new StringReader(powerUpFile.text);
        while ( (alias = sr.ReadLine()) != null ){
            if ( (desc = sr.ReadLine()) != null)
            {
                id = int.Parse(sr.ReadLine());
                tempPowerUp.alias = alias;
                tempPowerUp.desc = desc;
                //Associate Sprite
                tempPowerUp.sp = null;
                tempPowerUp.Id = id;
                powerUpDict.Add(alias,tempPowerUp);
            }
        }
    }

    public bool isPowerUp( Component someComp )
    {
        return powerUpDict.ContainsKey(someComp.tag);
    }

    public PowerUp getPowerUp( string name )
    {
        PowerUp reward;
        bool success;
        success = powerUpDict.TryGetValue(name, out reward);
        if(!success)
        {
            Debug.Log("getPowerUp:  Powerup not found!");
            reward.desc = "Default";
            reward.sp = null;
            reward.alias = "Default";
            reward.Id = -1;
        }
        return reward;
    }
}