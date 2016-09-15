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
            luaFile.SaveLua(stringToEdit,this.gameObject);
        }
	
	}

    void OnMouseDown()
    {
        luaFile.CreateLuaScriptForObject(this.gameObject);
        Debug.Log(luaFile.GetSource());
        Debug.Log(this.gameObject.name);
        string luaCode = luaFile.GetSource();
        stringToEdit = luaCode;
        gui.StringToEdit = stringToEdit;
        gui.SelectedGameObject = this.gameObject;
    }
}
