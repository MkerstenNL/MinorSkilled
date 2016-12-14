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
    // Use this for initialization
    void Init () {
        Debug.Assert(topLevelFile != "");
        _gameobjectLua = GetComponent<GameObjectLuaLink>();
        _lua = _gameobjectLua.lua;
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
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
        File.Delete(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
        File.Create(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua");
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/Lua/UserFiles/" + topLevelFile + ".lua", text);
    }
}
