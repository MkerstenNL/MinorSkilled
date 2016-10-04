using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CustomBehaviour : MonoBehaviour {

    protected string _name = "null";

    //name of the variable and the value of it. #HackIt420
    protected Dictionary<string, object> variableList = new Dictionary<string, object>();
    public Dictionary<string, object> VariableList {
        get {return variableList; }
    }

    public virtual void Init() {

    }

    public string GetName() {
        return _name;
    }

    public virtual CustomBehaviour Copy() {
        CustomBehaviour c = new CustomBehaviour();
        c.variableList = variableList;
        c._name = name;
        return c;

    }
}
