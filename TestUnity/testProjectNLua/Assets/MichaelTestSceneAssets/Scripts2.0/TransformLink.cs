using UnityEngine;
using System.Collections;
using NLua;
using System;
using System.Collections.Generic;

public class TransformLink : MonoBehaviour {
    Lua _lua;
    Dictionary<string, LuaFunction> _luaFunctions= new Dictionary<string, LuaFunction>();

    public void Init(Lua pLua) {
        _lua = pLua;
        _lua.DoFile(Environment.CurrentDirectory + "/Assets/Lua/engine/" + "Transform" + ".lua");
        _lua["cSharp"] = this;
        _luaFunctions.Add("Start", _lua.GetFunction("Start") as LuaFunction);
        _luaFunctions["Start"].Call();

    }

    public void GetPosition() {
        _lua.Push(this.transform.position.x);
        _lua.Push(this.transform.position.y);
        _lua.Push(this.transform.position.z);
        
        //return new object[3] {  this.transform.position.x,
        //                        this.transform.position.y,
        //                        this.transform.position.z};
    }

    public void Log(string s) {

        Debug.Log(s);
    }
    
}
