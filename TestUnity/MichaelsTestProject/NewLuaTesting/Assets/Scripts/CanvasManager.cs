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
        if (_lua.file == "Tutorial_Guard" || _lua.file == "Tutorial_BigGuard" || _lua.file == "Tutorial_Message" || _lua.file == "Tutorial_CreateObject")
        {
            string newPath = _lua.FileName.Replace(".lua", "_Restart.lua");
            string restartText = File.ReadAllText(newPath);
            //StreamReader srRestart = new StreamReader(newPath);
            //string restartText = sr.ReadToEnd();
            _input.text = restartText;
        }
        else
        {
            _input.text = "";
        }
        sr.Close();
        currentLuaFile = _lua;
        
    }

    public void SaveAndRun() {
        currentLuaFile.SetFile(_input.text);
        UsingHud = false;
        this.gameObject.SetActive(false);
    }
}
