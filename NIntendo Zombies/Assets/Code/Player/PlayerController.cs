using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour {
    private GameControllerSingleton gc;
    public Inventory myInv;
    public TextAsset FirstSaveFile;

    public float jumpMult = 2f;

    //                <powerup.alias, true/false>
    private List<string> hasPowerUp;

    void Awake()
    {
        hasPowerUp = new List<string>();
        gc = GameControllerSingleton.get();
        myInv = GetComponent<Inventory>();
    }
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gc.SaveGame( );
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            gc.LoadGame();
        }
	}

    void FixedUpdate()
    {
    }

    // Checks to see if the value is already in the dictionary with TryGetValue
    // Then Adds it if it is not.
    public void setPowerUp(GameControllerSingleton.PowerUp check)
    {
        if (!hasPowerUp.Contains(check.alias))
        {
            hasPowerUp.Add(check.alias);
        }
    }

    // Uses the dictionary remove method to remove our AppliedPowerUp
    public bool removePowerUp(string name)
    {
        return hasPowerUp.Remove(name);
    }


    public bool plrHasPowerUp( string name )
    {
        return hasPowerUp.Contains(name);
    }

    public void PlayerSave()
    {

    }
    public void PlayerLoad()
    {

    }

}

[Serializable]
class PlayerState
{
    public float health;
    public List<GameControllerSingleton.PowerUp> powerUps;
    public List<string> appliedPowerUps;

    PlayerState()
    {
        powerUps = new List<GameControllerSingleton.PowerUp>();
        appliedPowerUps = new List<string>();
    }
    
}
