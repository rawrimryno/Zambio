using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    GameControllerSingleton gameController;

	// Use this for initialization
	 void Start () {
        gameController = GameControllerSingleton.get();
	}
	
	// Update is called once per frame
	void Update () {
        gameController.Update();
	}
}
