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
    public string FileName {
        get {return Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua";}
    }
    // Use this for initialization
    void Init () {
        Debug.Assert(topLevelFile != "");
        _gameobjectLua = GetComponent<GameObjectLuaLink>();
        
        _layer = GetComponent<Lualayer>();
        _layer.Init();
        _lua = _gameobjectLua.lua;
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
        _lua.GetGlobal("Start");
        if ( _lua.IsFunction(-1) ) {
            _lua.PCall(0, 0, 0);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
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
