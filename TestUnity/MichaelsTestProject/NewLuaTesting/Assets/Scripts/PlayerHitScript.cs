using UnityEngine;
using System.Collections;
using System;
using UniLua;
using UnityEngine.UI;

public class PlayerHitScript : LuaLink
{
    void OnTriggerEnter(Collider other)
    {
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
        regFunction("TextTrigger", "Message", Message);
    }

    public int Message(ILuaState state)
    {
        if (state.GetTop() != 1)
        {
            _lua.SetTop(0);
            _lua.PushString("Invalid amount of parameters");

        }



        _lua.SetTop(0);
        _lua.PushString("HUD successfull");
        return 1;
    }
}
