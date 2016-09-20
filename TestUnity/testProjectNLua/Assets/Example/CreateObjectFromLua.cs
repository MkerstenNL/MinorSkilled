using UnityEngine;
using System.Collections;
using NLua;
using System;
using System.IO;

public class CreateObjectFromLua : MonoBehaviour {
    LuaContainerOfObject lua;
    OnGUIScript gui;
    string stringToEdit;
    bool isActive = false;
    public bool IsActive { get { return isActive; } set { isActive = value; } }
 	// Use this for initialization
    void Start()
    {
        lua = this.GetComponent<LuaContainerOfObject>();
        gui = GameObject.FindObjectOfType<OnGUIScript>();
        lua.Lua["create"] = this;

	}
	
	// Update is called once per frame
	void Update () {
        if (gui.IsButtonPressed)
        {
            Debug.Log(true);
            stringToEdit = gui.StringToEdit;
            lua.SaveLua(stringToEdit, this.gameObject,true);
        }	
	}

    public void ShowOnGUI(string showGUI)
    {
        GameObject.FindObjectOfType<OnGUIScript>().StringToEdit = showGUI;
        stringToEdit = showGUI;
    }

    public static void CreateObject(string pName)
    {
        GameObject prefab = (GameObject)Resources.Load(pName);
    }

    void GUI()
    {

    }
}
