using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class OnGUIScript : MonoBehaviour {

    bool buttonPressed;
    string stringToEdit;
    GameObject selectedGameObject;
    string oldText;
    bool isOldTextSaved;

    public bool IsButtonPressed { get { return buttonPressed; } }
    public string StringToEdit { get { return stringToEdit; } set { stringToEdit = value; } }
    public GameObject SelectedGameObject { get { return selectedGameObject; } set { selectedGameObject = value; } }

    public bool IsOldTextSaved { get { return isOldTextSaved; } set { isOldTextSaved = value; } }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.LeftAlt)&&Input.GetKeyDown(KeyCode.Equals))
        {
            if (stringToEdit != "")
            {
                if (SelectedGameObject != null)
                {
                    System.Diagnostics.Process.Start("notepad++.exe", Environment.CurrentDirectory + "/Assets/Example/" + selectedGameObject.name + ".lua");
                }
            }
        }
        if (oldText != stringToEdit)
        {
            string checkOnDot = stringToEdit.Replace(oldText, "");
            if (checkOnDot.LastIndexOf(".") == checkOnDot.Length -1)
            {
                Debug.Log(true);
            }
        }
    }


    void OnGUI()
    {
        if (isOldTextSaved == false && (stringToEdit != null || stringToEdit != ""))
        {
            oldText = stringToEdit;
            isOldTextSaved = true;
        }
        //Debug.Log(this);
        GUI.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        stringToEdit = GUI.TextArea(new Rect(10, 10, 500, 900), stringToEdit);
        buttonPressed = GUI.Button(new Rect(600, 10, 200, 30), "Save");
        if (buttonPressed)
        {
            oldText = stringToEdit;
            isOldTextSaved = false;
        }
    }  
}
