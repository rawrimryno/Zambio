using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {
    GameControllerSingleton gc; //GameController
    public TextAsset powerUpText;

	// Use this for initialization
	 void Start () {
        gc = GameControllerSingleton.get();
        gc.loadPowerUps(powerUpText);
    }
	
	// Update is called once per frame
	void Update () {
        gc.Update();

    }

    void OnGUI()
    {
        // Just Checking some of the save/load procedures
        GUI.Label(new Rect(10, 10, 140, 50), "Time Played " + Math.Floor(gc.timePlayed / 60) + ":" + Math.Floor(gc.timePlayed % 60));
    }
}
