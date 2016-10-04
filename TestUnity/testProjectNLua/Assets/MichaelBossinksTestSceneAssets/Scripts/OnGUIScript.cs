using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class OnGUIScript : MonoBehaviour {

    bool buttonPressed;
    bool buttonPressedStart;
    bool buttonPressedSaveGame;
    bool buttonPressedLoadGame;
    string stringToEdit = "";
    string saveName = "";
    GameObject selectedGameObject;
    //string oldText;
    //bool isOldTextSaved;

    public bool IsButtonPressed { get { return buttonPressed; } }
    public string StringToEdit { get { return stringToEdit; } set { stringToEdit = value; } }
    public GameObject SelectedGameObject { get { return selectedGameObject; } set { selectedGameObject = value; } }

    //public bool IsOldTextSaved { get { return isOldTextSaved; } set { isOldTextSaved = value; } }

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
        //change this to a run function
        if (buttonPressedStart)
        {
            foreach (IsClickedOnMouse gameObject in GameObject.FindObjectsOfType<IsClickedOnMouse>())
            {
                gameObject.ActiveScripts();
            }
        }
       /* if (buttonPressedSaveGame)
        {
            SaveCurrentScene.SaveJsonScene(GameObject.FindObjectsOfType<GameObject>().ToList(),saveName);
        }
        if (buttonPressedLoadGame)
        {
            foreach (IsClickedOnMouse destoryedGameObject in GameObject.FindObjectsOfType<IsClickedOnMouse>())
            {
                Destroy(destoryedGameObject.gameObject);
            }
            SaveCurrentScene.LoadJsonScene(saveName);
        }*/
    //    if (oldText != stringToEdit)
    //    {
    //        string checkOnDot = stringToEdit.Replace(oldText, "");
    //        if (checkOnDot.LastIndexOf(".") == checkOnDot.Length -1)
    //        {
    //            Debug.Log(true);
    //        }
    //    }
    }


    void OnGUI()
    {
        //if (isOldTextSaved == false && (stringToEdit != null || stringToEdit != ""))
        //{
        //    oldText = stringToEdit;
        //    isOldTextSaved = true;
        //}
        GUI.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        stringToEdit = GUI.TextArea(new Rect(10, 10, 500, 900), stringToEdit);
        buttonPressed = GUI.Button(new Rect(600, 10, 200, 30), "Save");
        buttonPressedStart = GUI.Button(new Rect(600, 50, 200, 30), "Start");
        buttonPressedSaveGame = GUI.Button(new Rect(600, 90, 200, 30), "SaveGame");
        saveName = GUI.TextField(new Rect(600, 120, 200, 30),saveName);
        buttonPressedLoadGame = GUI.Button(new Rect(600, 160, 200, 30), "LoadGame");
        //if (buttonPressed)
        //{
        //    oldText = stringToEdit;
        //    isOldTextSaved = false;
        //}
    }  
}
