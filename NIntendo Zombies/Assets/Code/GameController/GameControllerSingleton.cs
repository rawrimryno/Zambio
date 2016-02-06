using UnityEngine;
using System.Collections;

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

    }

    // Update is called once per frame
    // Main Game Logic Flow, Coroutine to do time dependent things.
    public void Update()
    {


    }

    public PowerUp getPowerUp( string name )
    {
        PowerUp reward;
        reward = new PowerUp();
        // I think a dictionary is what we need here, but I need to look into it more,
        // so here is something that should work, albeit outdated
        if ( name == "Fire")
        {
            reward.desc = "The fire power-up!  It does firey things....";
            reward.Id = 1;
            reward.sp = null;
            reward.alias = "Fire";
        }
        else if ( name == "SuperJump") {
            reward.desc = "Allows you to jump a higher!";
            reward.Id = 2;
            reward.sp = null;
            reward.alias = "SuperJump";
        }
        else
        {
            reward.desc = "Default";
            reward.sp = null;
            reward.alias = "Default";
            reward.Id = -1;
        }
        return reward;
    }
}