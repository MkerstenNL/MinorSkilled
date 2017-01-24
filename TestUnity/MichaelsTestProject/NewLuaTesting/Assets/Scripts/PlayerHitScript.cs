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
    private InputField _input;
    [SerializeField]
    private GameObject _messageCanvas;

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

        if (other.name == "Boat")
        {
            Collider[] colliders = other.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                if (collider.isTrigger)
                {
                    collider.enabled = false;
                }
            }
        }
        if (other.name == "TriggerLevel5Coin")
        {
            //reset after bribing the woman guard
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Coins: 0";
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Boat")
        {
            Collider[] colliders = other.gameObject.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }
    void Message(string message, int tip)
    {
        Debug.Log(message);
        if (tip == 1)
        {
            //Debug.Log(GameObject.Find("Tip"));
            _input.GetComponentInChildren<Text>().text = message;
            _messageCanvas.active = false;
            //GameObject.Find("TipText").GetComponent<Text>().text = message;
            //Debug.Log(GameObject.Find("Tiptext").GetComponent<Text>().text);
        }
        else
        {
            _messageCanvas.active = true;
            _messageCanvas.GetComponentInChildren<Text>().text = message;
            //GameObject.Find("Messagtext").GetComponent<Text>().text = message;
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
