using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour {

    bool buttonPressed;
    string stringToEdit;
    GameObject selectedGameObject;

    public bool IsButtonPressed { get { return buttonPressed; } }
    public string StringToEdit { get { return stringToEdit; } set { stringToEdit = value; } }
    public GameObject SelectedGameObject { get { return selectedGameObject; } set { selectedGameObject = value; } }

    void OnGUI()
    {
        //Debug.Log(this);
        GUI.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        stringToEdit = GUI.TextArea(new Rect(10, 10, 500, 900), stringToEdit);
        buttonPressed = GUI.Button(new Rect(600, 10, 200, 30), "Save");     
    }  
}
