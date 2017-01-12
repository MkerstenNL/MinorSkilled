using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ScriptFactory : MonoBehaviour {
    private Dictionary<string, Type> _scriptList = new Dictionary<string, Type>();

    private void fillDict() {
        _scriptList.Add("Transform", typeof(TransformLuaLink));
        _scriptList.Add("RigidBody", typeof(RigidBodyLink));
        _scriptList.Add("HUD", typeof(HUDLuaLink));
        _scriptList.Add("World",typeof(WorldLuaLink));

    }

    public Type GetScriptType(string name) {
        if ( _scriptList.Count == 0 )
            fillDict();
        try {
            return _scriptList[name];
        } catch(Exception e) {
            Debug.Log(e.Message);
        }

        return null;
    }
}
