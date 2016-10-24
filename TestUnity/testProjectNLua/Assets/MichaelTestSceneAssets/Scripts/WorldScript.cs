using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class WorldScript : MonoBehaviour {
    GameObject[] gameObjects;

    string[] luaFiles;



    // Use this for initialization
    void Start () {
        Invalidate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// refreshes the list of all gameobjects.
    /// </summary>
    public void Invalidate() {
        gameObjects = this.gameObject.GetComponentsInChildren<GameObject>();
        luaFiles = Directory.GetFiles(Environment.CurrentDirectory+"/Assets/Lua", "*.txt");
       
    }

    public string[] getLuaFiles() {
        return luaFiles;
    }

    /// <summary>
    /// activates all behaviours and lua scripts
    /// </summary>
    private void activateAll() {
        

    }

    /// <summary>
    /// resets all of the objects back to its original position
    /// </summary>
    private void reset() {


    }
}
