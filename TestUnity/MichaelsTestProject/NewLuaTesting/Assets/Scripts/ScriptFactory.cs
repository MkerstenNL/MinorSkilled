using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ScriptFactory : MonoBehaviour {
    private Dictionary<string, Type> _scriptList = new Dictionary<string, Type>();

    void Awake() {
        fillDict();

    }

    private void fillDict() {
        _scriptList.Add("Transform", typeof(TransformLuaLink));
        _scriptList.Add("RigidBody", typeof(RigidBodyLink));

    }

    public Type GetScriptType(string name) {
        
        try {
            return _scriptList[name];
        } catch(Exception e) {
            Debug.Log(e.Message);
        }

        return null;
    }
}
