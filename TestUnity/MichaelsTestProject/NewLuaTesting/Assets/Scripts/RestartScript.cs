using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartLuaPlayer[] restartScripts = this.GetComponents<StartLuaPlayer>();
            foreach (StartLuaPlayer restart in restartScripts)
            {
                StreamReader srRestart = new StreamReader(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/Tutorial_" + restart.Layername + "_Restart.lua");
                string textToWrite = srRestart.ReadToEnd();
                File.WriteAllText(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/Tutorial_" + restart.Layername + ".lua", textToWrite);
            }
            StreamReader srRestartBoat = new StreamReader(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/Tutorial_Boat_Restart.lua");
            string textToWriteBoat = srRestartBoat.ReadToEnd();
            File.WriteAllText(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/Tutorial_Boat.lua", textToWriteBoat);
        }
    }
}
