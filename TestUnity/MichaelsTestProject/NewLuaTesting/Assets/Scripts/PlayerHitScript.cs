using UnityEngine;
using System.Collections;
using System;
using UniLua;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHitScript : LuaLink
{

    NameFuncPair[] _lib = new NameFuncPair[1];
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
            //lua.GetGlobal("Message");
            //string message;
            //int nummer;
            //if (lua.IsString(-1))
            //{

            //}
            //lua.GetGlobal("MessageNumber");
            //Debug.Log(lua.ToNumber(-1));
            //Message()
        }

        //Debug.Log(lua.ToString(-2));
        /*
        if (other.gameObject.name == "StartTrigger")
        {
            Message("Try to escape the prison the door looks unguarded", 0);
        }
    
    if (other.gameObject.name == "Door")
        {
            Message("Try opening the door by typing Door:Open()", 1);
        }

        if (other.gameObject.name == "triggerWalkedThroughDoorLevel1")
        {
        Message("Good Job. You used a function for an object. Is that a coin? Free money! Let's pick it up.", 0);
        }

        if (other.gameObject.name == "Coin")
        {
         Message("Tip:Coin.PickUp()", 1);
        }

        if (other.gameObject.name == "TriggerPickedUpCoin")
        {
        Message("Nice you have some money now and again you used a function but for another object. Let's continue.", 0);
        }

        if (other.gameObject.name == "triggerWaterLevel3") {
         Message("The boat is coming our way. Someone is trying to help you. How does the boat operate?", 0);
        }
        if (other.gameObject.name == "Boat") {
        Message("Hee, someone programmed the boat that is was going in your direction. Now you need to go the opposite direction.", 1);
        }

        if (other.gameObject.name == "triggerWaterBoatEndLevel3") {
            Message("Using a function with parameters. Nice! but what did the text and number show you? The text was the direction and the number the amount in meters.", 0);
        }


        if (other.gameObject.name == "triggerLevel4")
        {
            Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can go Toward the Coin, but how to get back? You can continue if you want to.", 0);
        }

        if (other.gameObject.name == "TriggerLevel4Coin") {
            Message("So you went for the coin and used the gameobject. But how to get back. If there is forward and backwards. Maybe there is also right and left. Try more then just one line of code.", 1);
        }

        if (other.gameObject.name == "triggerLevelCoinEnd4") {
            Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.", 0);
        }
        */

    }
    void Message(string message, int tip)
    {
        Debug.Log(message);
        if (tip == 1)
        {
            //Debug.Log(GameObject.Find("Tip"));
            GameObject.Find("TipText").GetComponent<Text>().text = message;
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
            _lua.PushString("Invalid amount of parameters");

        }
        int MessageType = (int)_lua.ToNumber(2);
        string Text = _lua.ToString(1);
        Message(Text, MessageType);

        _lua.SetTop(0);
        //_lua.PushString("Message");
        return 0;
    }
}
