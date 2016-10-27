using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// A class of keeping track of objects created in lua
/// </summary>
public class LuaObjectManager {

    List<GameObject> _objectList = new List<GameObject>();
    public LuaObjectManager() {

    }

    //object stuff
    /// <summary>
    /// Adds the object to the list
    /// </summary>
    /// <param name="pGameObject"></param>
    public void AddObject(GameObject pGameObject) {
        _objectList.Add(pGameObject);

    }
    /// <summary>
    /// deletes all objects in the list
    /// </summary>
    public void ClearList() {
        foreach ( GameObject go in _objectList ) {
            GameObject.Destroy(go);
        }
    }



}
