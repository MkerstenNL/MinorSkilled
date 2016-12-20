using UnityEngine;
using System.Collections.Generic;
using UniLua;
using System;
using System.IO;

[RequireComponent(typeof(GameObjectLuaLink))]
[RequireComponent(typeof(TopLevelLua))]
public class Lualayer : MonoBehaviour {
    ILuaState _lua;
    GameObjectLuaLink _gameobjectLua;
    WorldLuaLink _world;
    [SerializeField]string luaLayerFile = "";
	// Use this for initialization
	void Start () {
        GetAvailableFunctions();
        Debug.Assert(luaLayerFile != "");
        _gameobjectLua = GetComponent<GameObjectLuaLink>();
        //_world = GameObject.FindGameObjectWithTag("World").GetComponent<WorldLuaLink>();
        //_lua = _world.GetWorld(_lua);
        //_lua.SetGlobal("World");
        //_lua = _gameobjectLua.lua;
        //_lua.L_DoFile(Environment.CurrentDirectory+"/Assets/Lua/LuaLayer/"+luaLayerFile+".lua");

	}

    public void Init() {
        _gameobjectLua.init();
        _lua = _gameobjectLua.lua;
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/LuaLayer/" + luaLayerFile + ".lua");
        _lua.GetGlobal(luaLayerFile);
        _lua.GetField(1,"Start");
        if(_lua.IsFunction(-1)){
            _lua.PCall(0, 0, 0);
        }
        //ToDo
    }

    public List<string> GetAvailableFunctions() {
        List<string> functions = new List<string>();
        StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/Assets/Lua/LuaLayer/" + luaLayerFile + ".lua");
        string alltext = sr.ReadToEnd();
        string[] textSplit = alltext.Split('\n');
        for ( int i = 0; i <textSplit.Length; i++ ) {
            string s = textSplit[i];
            if ( s.StartsWith("function") ) {
                functions.Add(s.Replace("function ", ""));
                Debug.Log(functions[functions.Count - 1]);
            }

        }
        return functions;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
