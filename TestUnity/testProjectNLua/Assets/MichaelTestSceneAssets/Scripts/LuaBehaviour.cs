using UnityEngine;
using System.Collections;
using NLua;
using System;
using System.IO;

public class LuaBehaviour : CustomBehaviour {
    public string filename = "";
    private Lua env = new Lua();
    public Lua Env {
        get{
            return env;
        }
    }
    public string source = "";
    private string luaSource = "";

	// Use this for initialization
	void Start () {
        if (filename=="")return;
        CreateLuaScriptForObject(this.gameObject, this, filename);
        //Init();
        //env.DoFile(Environment.CurrentDirectory + "/Assets/Lua/" + filename + ".lua");
	}
	
	// Update is called once per frame
	void Update () {
        if(!active)return;
        Call("Update");
	}

    public override void Init() {
        active = true;
        //env.DoFile(Environment.CurrentDirectory + "/Assets/Lua/" + filename + ".lua");
        env.DoString(source);

    }

    public static string LoadLuaFile(string pFilename) {
        string source = "";
        if ( File.Exists(Environment.CurrentDirectory + "/Assets/Lua/" + pFilename + ".lua") ) {
            source = File.ReadAllText(Environment.CurrentDirectory + "/Assets/Lua/" + pFilename + ".lua");
        } else {
            Debug.Log("File Doesnt Exist");
            return "";
        }
        return source;
    }

    public static void CreateLuaScriptForObject(GameObject obj, LuaBehaviour lua, string filename ) {
        lua.filename = filename;
        
        if ( filename != null ) {
            if ( !File.Exists(Environment.CurrentDirectory + "/Assets/Lua/" + filename + ".lua") ) {
                File.Create(Environment.CurrentDirectory + "/Assets/Lua/" + filename + ".lua").Dispose();
            }
            lua.source = File.ReadAllText(Environment.CurrentDirectory + "/Assets/Lua/" + filename + ".lua");
            
            Debug.Log(lua.source);
            //stringToEdit = File.ReadAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + _gameObject.name + ".lua");
            Debug.Log("test");
            lua.Env["this"] = obj.GetComponent<LuaCSharpFunctions>(); // Give the script access to the gameobject.
            lua.Env["transform"] = obj.transform;

            try {
                //result = env.DoString(source);
                lua.Env.DoString(lua.source);
            } catch ( NLua.Exceptions.LuaException e ) {
                Debug.LogError(FormatException(e), obj);
            }
        }

    }

    public void SaveLua(string pStringToEdit, string pFilename, bool pIsWorld = false) {
        //Debug.Log(pStringToEdit);
        //Debug.Log(pGameObject.name);
        
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/Lua/" + pFilename + ".lua", "");
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/Lua/" + pFilename + ".lua", pStringToEdit);
        //_gameObject = GameObject.Find(pGameObjectName);
        // if ( pIsWorld ) {
        //     _gameObject.GetComponent<CreateObjectFromLua>().ShowOnGUI(pStringToEdit);
        // }
        env.LoadCLRPackage();
        LuaBehaviour.CreateLuaScriptForObject(this.gameObject,this,pFilename);
        filename = pFilename;

    }

    public System.Object[] Call(string function) {
        return Call(function, null);
    }

    public System.Object[] Call(string function, params System.Object[] args) {
        System.Object[] result = new System.Object[0];
        if ( env == null ) return result;
        LuaFunction lf = env.GetFunction(function);
        if ( lf == null ) return result;

        try {
            // Note: calling a function that does not 
            // exist does not throw an exception.
            if ( args != null ) {
                result = lf.Call(args);
            } else {
                result = lf.Call();
            }
        } catch ( NLua.Exceptions.LuaException e ) {
            Debug.LogError(FormatException(e), gameObject);
            throw e;
        }
        return result;
    }

    public static string FormatException(NLua.Exceptions.LuaException e) {
        string source = ( string.IsNullOrEmpty(e.Source) ) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
    }
}
