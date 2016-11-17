using UnityEngine;
using System.Collections;
using NLua;
using LuaState = KeraLua.LuaState;
using NLua.Event;
using NLua.Method;
using System.IO;
using System;
using System.Collections.Generic;

public class GameObjectLuaLink : MonoBehaviour {
    private Lua _lua = new Lua();
    
    [SerializeField]private string _filename = "";
    Dictionary<string, LuaFunction> _luaFunctions= new Dictionary<string, LuaFunction>(); 
    public void New() {
        

    }

	// Use this for initialization
	void Start () {
        _lua.DoFile(Environment.CurrentDirectory + "/Assets/Lua/engine/" + _filename + ".lua");
        _lua["cSharp"] = this;
        _lua["Name"] = this.gameObject.name;
        _luaFunctions.Add("Start", _lua.GetFunction("Start") as LuaFunction);
        _luaFunctions["Start"].Call();
        //_lua.RegisterFunction()
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Log(string s) {
        Debug.Log(s);

    }
}
