using UnityEngine;
using System.Collections;
using UniLua;
using System;
using UnityEngine.UI;

public class HUDLua : LuaLink {
    protected override void registerFunctions()
    {
        regFunction("HUD", "Message", Message);
    }
    public int Message(ILuaState state)
    {
        if (state.GetTop() != 1)
        {
            _lua.SetTop(0);
            //_lua.PushString("Invalid amount of parameters");

        }
            
        

        _lua.SetTop(0);
        //_lua.PushString("HUD successfull");
        return 0;
    }

}
