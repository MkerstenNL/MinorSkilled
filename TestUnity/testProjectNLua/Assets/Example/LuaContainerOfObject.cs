using UnityEngine;
using System.Collections;
using NLua;
using System.IO;
using System;

public class LuaContainerOfObject : MonoBehaviour {

	// Use this for initialization
    Lua env;
    public Lua Lua { get { return env; } set { env = value; } }
    string source = "";
    string stringToEdit = "";
    GameObject gameObject;

    public string GetSource()
    {
        return source;
    }
	void Start () {

        CreateLuaScriptForObject(this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.N))
        {
            GameObject.FindObjectOfType<CreateObjectFromLua>().IsActive = true;
            CreateLuaScriptForObject(GameObject.FindObjectOfType<CreateObjectFromLua>().gameObject);
            GameObject.FindObjectOfType<CreateObjectFromLua>().ShowOnGUI(source);
        }
        Call("Update");
	}

    public void CreateLuaScriptForObject(GameObject gameObject)
    {
        
        env = new Lua();
        env.LoadCLRPackage();


        if (!File.Exists(Environment.CurrentDirectory + "/Assets/Example/" + gameObject.name + ".lua"))
        {
            File.Create(Environment.CurrentDirectory + "/Assets/Example/" + gameObject.name + ".lua");
        }
        source = File.ReadAllText(Environment.CurrentDirectory + "/Assets/Example/" + gameObject.name + ".lua");
        stringToEdit = File.ReadAllText(Environment.CurrentDirectory + "/Assets/Example/" + gameObject.name + ".lua");

        env["this"] = this; // Give the script access to the gameobject.
        env["transform"] = transform;

        //System.Object[] result = new System.Object[0];
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
    public static string FormatException(NLua.Exceptions.LuaException e)
    {
        string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
    }
    public void SaveLua(string pStringToEdit, GameObject pGameObject, bool pIsWorld = false)
    {
        Debug.Log(pStringToEdit);
        Debug.Log(pGameObject.name);
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/Example/" + pGameObject.name + ".lua", "");
        File.WriteAllText(Environment.CurrentDirectory + "/Assets/Example/" + pGameObject.name + ".lua", pStringToEdit);
        CreateLuaScriptForObject(pGameObject);
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

    public void CreateObject(string pName)
    {
        if (!GameObject.Find(pName))
        {
            Debug.Log(pName);
            GameObject prefab = Resources.Load(pName) as GameObject;
            Debug.Log(prefab);
            gameObject = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
        if (gameObject.GetComponent<IsClickedOnMouse>() != null)
        {
            gameObject.AddComponent<IsClickedOnMouse>();
        }
        if (gameObject.GetComponent<LuaContainerOfObject>() != null)
        {
            gameObject.AddComponent<LuaContainerOfObject>();
        }


    }
}
