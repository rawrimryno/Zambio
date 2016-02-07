using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private Dictionary<string, PowerUp> powerUpDict = new Dictionary<string, PowerUp>();

    public static GameControllerSingleton get()
    {
        if (Instance == null)
        {
            Instance = ScriptableObject.CreateInstance<GameControllerSingleton>();
            Instance.Start();
        }

        return Instance;
    }
    // Use this for initialization 
    public void Start()
    {
        // Hack Method until they are put into text files
        PowerUp tempPowerUp;
        tempPowerUp.desc = "The fire power-up!  It does firey things....";
        tempPowerUp.Id = 1;
        tempPowerUp.sp = null;
        tempPowerUp.alias = "Fire";
        powerUpDict.Add("Fire", tempPowerUp);
        tempPowerUp.desc = "Allows you to jump a higher!";
        tempPowerUp.Id = 2;
        tempPowerUp.sp = null;
        tempPowerUp.alias = "SuperJump";
        powerUpDict.Add("SuperJump", tempPowerUp);

    }

    // Update is called once per frame
    // Main Game Logic Flow, Coroutine to do time dependent things.
    public void Update()
    {


    }

    public void loadPowerUps( TextAsset powerUpFile )
    {
        //Load info from file not sure on C# and TextAsset, will start later
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