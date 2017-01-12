using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CanvasManager : MonoBehaviour {
    [SerializeField]private InputField _input;
    public static bool UsingHud = false;
    TopLevelLua currentLuaFile  = null;
    void Awake()
    {
        
    }
    void LateStart() {
        gameObject.SetActive(false);
    }

    public void LoadScript(TopLevelLua _lua) {
        UsingHud = true;
        this.gameObject.SetActive(true);
        StreamReader sr = new StreamReader(_lua.FileName);
        string s = sr.ReadToEnd();
        _input.text = s;
        sr.Close();
        currentLuaFile = _lua;
        
    }

    public void SaveAndRun() {
        currentLuaFile.SetFile(_input.text);
        UsingHud = false;
        this.gameObject.SetActive(false);
    }
}
