using UnityEngine;
using System.Collections;

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
}
