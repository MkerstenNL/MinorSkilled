using UnityEngine;
using System.Collections;
using UniLua;
using System;
using System.IO;

public class TopLevelLua : MonoBehaviour {
    ILuaState _lua;
    GameObjectLuaLink _gameobjectLua;
    [SerializeField]
    string topLevelFile = "";
    Lualayer _layer;
    public string file {
        get {
            return topLevelFile;
        }
    }
    public string FileName {
        get {return Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua";}
    }
    // Use this for initialization
    public void Init() {
        Debug.Assert(topLevelFile != "");
        _gameobjectLua = GetComponent<GameObjectLuaLink>();

        _layer = GetComponent<Lualayer>();
        _layer.Init();
        _lua = _gameobjectLua.lua;
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
        try {

            _lua.GetGlobal(topLevelFile);
            _lua.GetField(1, "Start");
            if ( _lua.IsFunction(-1) ) {
                _lua.PCall(0, 0, 0);
            }
        } catch { } 
        _lua.SetTop(0);
    }

    // Update is called once per frame
    void Update() {
        if (_lua==null)return;
        _lua.GetGlobal(topLevelFile);
        try {

            _lua.GetField(1, "Update");
            if ( _lua.IsFunction(-1) ) {
                _lua.PCall(0, 0, 0);
            }
        } catch {

        }
        
        _lua.SetTop(0);
    }



    public string GetFile() {
        Debug.Assert(topLevelFile != "");
        StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
        return sr.ReadToEnd();
    }

    public void SetFile(string text) {
        Debug.Assert(topLevelFile != "");
        File.WriteAllText(FileName, text);
        Init();
    }
}
