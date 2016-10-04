using UnityEngine;
using System.Collections;
using NLua;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LuaContainerOfObject : MonoBehaviour {

	// Use this for initialization
    Lua env;
    public Lua Lua { get { return env; } set { env = value; } }
    string source = "";
    string stringToEdit = "";
    GameObject _gameObject;


    public GameObject GameObject { set { _gameObject = value; } }

    public string GetSource()
    {
        return source;
    }
	void Start () {

        env = new Lua();
        env.LoadCLRPackage();
	}
	
	// Update is called once per frame
	void Update () {

        Call("Update");
	}

    public void CreateLuaScriptForObject()
    {
        if (_gameObject != null)
        {
            if (!File.Exists(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + _gameObject.name + ".lua"))
            {
                File.Create(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + _gameObject.name + ".lua").Dispose();
            }
            source = File.ReadAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + _gameObject.name + ".lua");
            //stringToEdit = File.ReadAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + _gameObject.name + ".lua");

            env["this"] = this; // Give the script access to the gameobject.
            env["transform"] = transform;

            try
            {
                //result = env.DoString(source);
                env.DoString(source);
            }
            catch (NLua.Exceptions.LuaException e)
            {
                Debug.LogError(FormatException(e), gameObject);
            }
        }
        
    }
    public static string FormatException(NLua.Exceptions.LuaException e)
    {
        string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
    }
    public void SaveLua(string pStringToEdit, string pGameObjectName, bool pIsWorld = false)
    {
        //Debug.Log(pStringToEdit);
        //Debug.Log(pGameObject.name);
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + pGameObjectName + ".lua", "");
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Lua/" + pGameObjectName + ".lua", pStringToEdit);
        _gameObject = GameObject.Find(pGameObjectName);
        if (pIsWorld)
        {
            _gameObject.GetComponent<CreateObjectFromLua>().ShowOnGUI(pStringToEdit);
        }
        CreateLuaScriptForObject();
        
    }
    public System.Object[] Call(string function)
    {
        return Call(function, null);
    }
    public System.Object[] Call(string function, params System.Object[] args)
    {
        System.Object[] result = new System.Object[0];
        if (env == null) return result;
        LuaFunction lf = env.GetFunction(function);
        if (lf == null) return result;
        try
        {
            // Note: calling a function that does not 
            // exist does not throw an exception.
            if (args != null)
            {
                result = lf.Call(args);
            }
            else
            {
                result = lf.Call();
            }
        }
        catch (NLua.Exceptions.LuaException e)
        {
            Debug.LogError(FormatException(e), gameObject);
            throw e;
        }
        return result;
    }

    /*
    public LuaCSharpFunctions CreateObject(string pName, string pSource = "")
    {
        GameObject prefab = Resources.Load(pName) as GameObject;
        Debug.Log(prefab);
        if (pName == "World" && pSource != "")
        {
            _gameObject = GameObject.FindObjectOfType<CreateObjectFromLua>().gameObject;
            _gameObject.GetComponent<CreateObjectFromLua>().ShowOnGUI(pSource);
            Debug.Log(pSource);
            SaveLua(pSource, _gameObject.name, true);
        }
        else if (prefab != null && pSource != "")
        {
            _gameObject = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
            _gameObject.name = _gameObject.name.Replace("(Clone)", "");
            if (_gameObject.GetComponent<IsClickedOnMouse>() == null)
            {
                _gameObject.AddComponent<IsClickedOnMouse>();
            }
            if (_gameObject.GetComponent<LuaContainerOfObject>() == null)
            {
                _gameObject.AddComponent<LuaContainerOfObject>();
            }
            if (_gameObject.GetComponent<Collider>() == null)
            {
                _gameObject.AddComponent<MeshCollider>();
            }
            if (_gameObject.GetComponent<LuaCSharpFunctions>() == null)
            {
                _gameObject.AddComponent<LuaCSharpFunctions>();
            }
            SaveLua(pSource, _gameObject.name);
        }
        else if (prefab != null && pSource == "")
        {
            //Debug.Log(pName);
            //GameObject prefab = Resources.Load(pName) as GameObject;
            //Debug.Log(prefab);
            _gameObject = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
            _gameObject.name = _gameObject.name.Replace("(Clone)", "");
            if (_gameObject.GetComponent<IsClickedOnMouse>() == null)
            {
                _gameObject.AddComponent<IsClickedOnMouse>();
            }
            if (_gameObject.GetComponent<LuaContainerOfObject>() == null)
            {
                _gameObject.AddComponent<LuaContainerOfObject>();
            }
            if (_gameObject.GetComponent<Collider>() == null)
            {
                _gameObject.AddComponent<MeshCollider>();
            }
            if (_gameObject.GetComponent<LuaCSharpFunctions>() == null)
            {
                _gameObject.AddComponent<LuaCSharpFunctions>();
            }
            //return _gameObject.GetComponent<LuaCSharpFunctions>();
        }
            return _gameObject.GetComponent<LuaCSharpFunctions>();
        #region old
        //CreateLuaScriptForObject();
            //_gameObject.GetComponent<IsClickedOnMouse>().ActiveScripts();
            //if (_gameObject.GetComponent<IsClickedOnMouse>() != null)
           // {
                //_gameObject.AddComponent<IsClickedOnMouse>();
                //_gameObject.AddComponent<LuaContainerOfObject>();
                //_gameObject.AddComponent<Collider>();
           // }
        //}
            /*
        else
        {
            string[] split = Regex.Split(source,":");
            int index = 0;
            int count = 0;
            Debug.Log(split);
            while (split.Contains("CreateObject('Cube')"))
            {
                if (count > 0 && split[index].Contains("CreateObject('Cube')"))
                {
                    Debug.Log(false);
                    GameObject prefab = Resources.Load(pName) as GameObject;
                    //Debug.Log(prefab);
                    _gameObject = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
                    _gameObject.name = _gameObject.name.Replace("(Clone)", "");
                    if (_gameObject.GetComponent<IsClickedOnMouse>() == null)
                    {
                        _gameObject.AddComponent<IsClickedOnMouse>();
                    }
                    if (_gameObject.GetComponent<LuaContainerOfObject>() == null)
                    {
                        _gameObject.AddComponent<LuaContainerOfObject>();
                    }
                    if (_gameObject.GetComponent<Collider>() == null)
                    {
                        _gameObject.AddComponent<MeshCollider>();
                    }
                    split[index] = null;
                }
                else if (split[index].Contains("CreateObject('Cube')"))
                {
                    Debug.Log(true);
                    count++;
                    split[index] = null;
                }

                index++;
            }
            //int count = Regex.Matches(source, "this:CreateObject('Cube')", RegexOptions.Multiline|RegexOptions.IgnoreCase|RegexOptions.IgnorePatternWhitespace).Count;
            //Debug.Log("Coming here" + source);
           // Debug.Log(count);
        }
             */
        //if (gameObject.GetComponent<LuaContainerOfObject>() != null)
        //{
        //    gameObject.AddComponent<LuaContainerOfObject>();
        //}


    //}
    public LuaCSharpFunctions CreateObject(string pName, string pSource = "")
    {
        GameObject prefab = Resources.Load(pName) as GameObject;
        //Debug.Log(prefab);
        _gameObject = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        _gameObject.name = _gameObject.name.Replace("(Clone)", "");
        if (_gameObject.GetComponent<IsClickedOnMouse>() == null)
        {
            _gameObject.AddComponent<IsClickedOnMouse>();
        }
        if (_gameObject.GetComponent<LuaContainerOfObject>() == null)
        {
            _gameObject.AddComponent<LuaContainerOfObject>();
        }
        if (_gameObject.GetComponent<Collider>() == null)
        {
            _gameObject.AddComponent<MeshCollider>();
        }
        if (_gameObject.GetComponent<LuaCSharpFunctions>() == null)
        {
            _gameObject.AddComponent<LuaCSharpFunctions>();
        }
        return _gameObject.GetComponent<LuaCSharpFunctions>();
    }
    

}
