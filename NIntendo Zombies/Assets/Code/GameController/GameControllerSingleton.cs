using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameControllerSingleton : ScriptableObject
{
    private static GameControllerSingleton Instance;
    private Inventory plr1Inv;

    public int level;
    public int wave;
    public float roundTime=0f;
    public float timePlayed=0f;

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
        timePlayed += Time.deltaTime;

    }

    // Save/Load State
    public void SaveState(TextAsset saveFile, PlayerController pc)
    {
        if (saveFile == null)
        {
            saveFile = new TextAsset();
            AssetDatabase.CreateAsset(saveFile, "Assets/Saves/newSave.txt");
        }
        Debug.Log("Calling GC::SaveState");
        pc.myInv.saveContents(saveFile);

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
                Debug.Log(alias + " added.");
                
            }
        }
    }

    public bool isPowerUp( Component someComp )
    {
        bool result = powerUpDict.ContainsKey(someComp.tag);
        return result;
    }

    public PowerUp getPowerUp( string name )
    {
        PowerUp reward = new PowerUp();
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

    public void stopTime()
    {
        Time.timeScale = 0f;
    }

    public void pauseGame()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        stopTime();
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/gameState.dat");
        GameState data = new GameState();

        data.wave = wave;
        data.level = level;
        data.roundTime = roundTime;
        data.timePlayed = timePlayed;

        bf.Serialize(fs, data);
        fs.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gameState.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/gameState.dat", FileMode.Open);
            GameState data = (GameState) bf.Deserialize(fs);
            fs.Close();

            wave = data.wave;
            level = data.level;
            roundTime = data.roundTime;
            timePlayed = data.timePlayed;
        }
    }
}
[Serializable]
public class GameState
{
    public int wave;
    public int level;
    public float roundTime;
    public float timePlayed;
}