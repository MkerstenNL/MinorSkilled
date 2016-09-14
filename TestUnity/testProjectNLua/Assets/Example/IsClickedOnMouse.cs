using UnityEngine;
using System.Collections;

public class IsClickedOnMouse : MonoBehaviour {

	// Use this for initialization
    string stringToEdit = "";
    bool buttonPressed;
    LuaContainerOfObject luaFile;
    bool onMouseDownIsPressed = false;
    OnGUIScript gui;
	void Start () {
        luaFile = this.GetComponent<LuaContainerOfObject>();
        gui = GameObject.FindObjectOfType<OnGUIScript>();
	}
	
	// Update is called once per frame
	void Update () {

        if (gui.IsButtonPressed && gui.SelectedGameObject == this.gameObject)
        {
            stringToEdit = gui.StringToEdit;
            luaFile.SaveLua(stringToEdit,this.gameObject);
        }
	
	}

    void OnMouseDown()
    {
        Debug.Log(luaFile.GetSource());
        Debug.Log(this.gameObject.name);
        string luaCode = luaFile.GetSource();
        stringToEdit = luaCode;
        gui.StringToEdit = stringToEdit;
        gui.SelectedGameObject = this.gameObject;
    }
}
