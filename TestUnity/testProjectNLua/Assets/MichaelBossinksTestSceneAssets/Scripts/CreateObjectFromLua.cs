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
    string oldWorldSource = "";

 	// Use this for initialization
    void Start()
    {
        lua = this.GetComponent<LuaContainerOfObject>();
        gui = GameObject.FindObjectOfType<OnGUIScript>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.N))
        {
            foreach (IsClickedOnMouse destoryedGameObject in GameObject.FindObjectsOfType<IsClickedOnMouse>())
            {
                Destroy(destoryedGameObject.gameObject);
            }
            lua.GameObject = this.gameObject;
            isActive = true; 
            oldWorldSource = lua.GetSource();
            lua.CreateLuaScriptForObject();
            ShowOnGUI(lua.GetSource());
        }
        if (gui.IsButtonPressed && this.gameObject.name == "World" && isActive)
        {
            stringToEdit = gui.StringToEdit;
            if (this.gameObject.name == "World")
            {
                foreach (IsClickedOnMouse destoryedGameObject in GameObject.FindObjectsOfType<IsClickedOnMouse>())
                {
                    Destroy(destoryedGameObject.gameObject);
                }
                if (gui.StringToEdit != lua.GetSource())
                {
                    
                }
                lua.GameObject = this.gameObject;
                isActive = true;
                lua.SaveLua(stringToEdit, this.gameObject.name, true);
                ShowOnGUI(lua.GetSource());
            }
            isActive = true;
        }	
	}

    public void ShowOnGUI(string showGUI)
    {
        gui.StringToEdit = showGUI;
        stringToEdit = showGUI;
    }
    void GUI()
    {

    }
}
