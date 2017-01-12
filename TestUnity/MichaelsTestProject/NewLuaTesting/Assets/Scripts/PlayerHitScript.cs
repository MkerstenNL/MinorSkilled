using UnityEngine;
using System.Collections;
using System;
using UniLua;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHitScript : LuaLink
{

    NameFuncPair[] _lib = new NameFuncPair[1];
    [SerializeField]
    private InputField input;

    void Start()
    {
        this.init();
    }

    public override void init()
    {
        scriptName = "Messages";
        scriptLocation = "LuaLayer";
        base.init();
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        lua.GetGlobal("OnHit");
        lua.PushString(other.gameObject.name);
        
        if (lua.IsFunction(-2))
        {

            lua.PCall(1, 0, 0);
            lua.SetTop(0);
        }

    }
    void Message(string message, int tip)
    {
        Debug.Log(message);
        if (tip == 1)
        {
            //Debug.Log(GameObject.Find("Tip"));
            input.GetComponentInChildren<Text>().text = message;
            //GameObject.Find("TipText").GetComponent<Text>().text = message;
            //Debug.Log(GameObject.Find("Tiptext").GetComponent<Text>().text);
        }
        else
        {
            GameObject.Find("Messagtext").GetComponent<Text>().text = message;
        }
    }

    protected override void registerFunctions()
    {
        _lib[0] = new NameFuncPair("Message", Message);
        _lua.L_NewLib(_lib);
        _lua.SetGlobal("M");
    }

    public int Message(ILuaState state)
    {
        if (state.GetTop() != 2)
        {
            _lua.SetTop(0);
            //_lua.PushString("Invalid amount of parameters");

        }
        int MessageType = (int)_lua.ToNumber(2);
        string Text = _lua.ToString(1);
        Message(Text, MessageType);

        _lua.SetTop(0);
        //_lua.PushString("Message");
        return 0;
    }
}
