using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniLua;


public abstract class LuaLink : MonoBehaviour {
    protected ILuaState _lua = null;
    public ILuaState lua {
        get{return _lua;}
    }
    protected Dictionary<string, List<NameFuncPair>> _libs = new Dictionary<string, List<NameFuncPair>>();
    [SerializeField]protected string scriptLocation = "";
    [SerializeField]protected string scriptName = "";
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
        //_lua.L_LoadFile(Environment.CurrentDirectory + "/Assets/Lua/" + scriptLocation + "/" + scriptName + ".lua");
        state.L_DoFile(Environment.CurrentDirectory+"/Assets/Lua/"+scriptLocation+"/"+scriptName+".lua");
        //Debug.Log(state.GetTop());
        //_lua.GetTop();
        /*if ( _lua.IsTable(-1) ) {
            luaclass = _lua.ToObject(-1) as LuaTable;
            
            Debug.Log(luaclass);
        }*/
        //ThreadStatus status  = _lua.L_DoString("Require["+Environment.CurrentDirectory + "/Assets/Lua/" + scriptLocation + " / " + scriptName + ".lua]");
        //Debug.Log(status.ToString());
        registerFunctions();
    }
    
    /// <summary>
    /// can be overwritten but make sure to call the base first!
    /// </summary>
    public virtual void init() {
        _lua = new LuaState();
        //_lua.L_LoadFile(Environment.CurrentDirectory + "/Assets/Lua/" + scriptLocation + "/" + scriptName + ".lua");
        _lua.L_DoFile(Environment.CurrentDirectory + "/Assets/Lua/"+scriptLocation + "/" + scriptName+".lua");
        _lua.GetTop();
        _lua.L_OpenLibs();
        registerFunctions();
    }


    protected virtual void CallLuaFunction(string classname,string functionName) {
        _lua.GetGlobal(classname);
        _lua.GetField(1,functionName);
        if ( _lua.IsFunction(-1) ) {
            _lua.PCall(0, 0, 0);
            _lua.SetTop(0);
        }
    }

    public virtual int Log(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("incorrect number of arguments");
            return 1;
        }
        object message = state.ToObject(-1);
        Debug.Log(message.ToString());
        _lua.SetTop(0);
        //_lua.PushString("operation succesful");
        return 0;
    }


}
