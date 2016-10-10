using UnityEngine;
using System.Collections;

public class IsClickedOnMouse : MonoBehaviour {

	// Use this for initialization
    string stringToEdit = "";
    bool buttonPressed;
    LuaContainerOfObject luaFile;
    bool onMouseDownIsPressed = false;
    OnGUIScript gui;
    CreateObjectFromLua world;
	void Start () {
        luaFile = this.GetComponent<LuaContainerOfObject>();
        gui = GameObject.FindObjectOfType<OnGUIScript>();
        world = GameObject.FindObjectOfType<CreateObjectFromLua>();
	}
	
	// Update is called once per frame
	void Update () {

        if (gui.IsButtonPressed && gui.SelectedGameObject == this.gameObject && world.IsActive == false)
        {
            Debug.Log(this.gameObject);
            stringToEdit = gui.StringToEdit;
            if (this.gameObject.name != "World")
            {
                luaFile.SaveLua(stringToEdit,this.gameObject.name);
            }
        }
	
	}

    void OnMouseDown()
    {
        
        ActiveScripts();
        //gui.IsOldTextSaved = false;
    }

    public void ActiveScripts()
    {
        luaFile.GameObject = this.gameObject;
        luaFile.CreateLuaScriptForObject();
       // Debug.Log(luaFile.GetSource());
        //Debug.Log(this.gameObject.name);
        string luaCode = luaFile.GetSource();
        stringToEdit = luaCode;
        world.IsActive = false;
        gui.StringToEdit = stringToEdit;
        gui.SelectedGameObject = this.gameObject;
    }
}
