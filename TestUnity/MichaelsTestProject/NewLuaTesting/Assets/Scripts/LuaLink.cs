using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniLua;


public abstract class LuaLink : MonoBehaviour {
    protected ILuaState _lua = null;
    protected Dictionary<string, List<NameFuncPair>> _libs = new Dictionary<string, List<NameFuncPair>>();
    [SerializeField]protected string scriptLocation = "";
    [SerializeField]
    protected string scriptName = "";
    protected abstract void registerFunctions();

    protected void regFunction(string className, string functionName, CSharpFunctionDelegate function) {
        if ( !_libs.ContainsKey(className) ) {
            _libs.Add(className, new List<NameFuncPair>());
        }
        _libs[className].Add(new NameFuncPair(functionName, function));
    }
	// Use this for initialization
	void Start () {
        
	}
    public virtual void init(ILuaState state) {
        _lua = state;
        _lua.L_LoadFile(Environment.CurrentDirectory + "/Assets/Lua/" + scriptLocation + "/" + scriptName + ".lua");
        _lua.L_DoFile(Environment.CurrentDirectory+"/Assets/Lua/"+scriptLocation+"/"+scriptName+".lua");
        registerFunctions();
    }
    
    /// <summary>
    /// can be overwritten but make sure to call the base first!
    /// </summary>
    protected virtual void init() {
        _lua = new LuaState();
        _lua.L_LoadFile(Environment.CurrentDirectory + "/Assets/Lua/" + scriptLocation + "/" + scriptName + ".lua");
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/"+scriptLocation + "/" + scriptName+".lua");
        _lua.L_OpenLibs();
        registerFunctions();
        
    }


    protected virtual void CallLuaFunction(string functionName) {
        _lua.GetGlobal(functionName);
        if ( _lua.IsFunction(-1) ) {
            _lua.PCall(0, 0, 0);
        }
    }

    public virtual int Log(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("incorrect number of arguments");
            return 1;
        }
        string message = state.ToObject(1).ToString();
        Debug.Log(message.ToString());
        _lua.SetTop(0);
        //_lua.PushString("operation succesful");
        return 1;
    }


}
