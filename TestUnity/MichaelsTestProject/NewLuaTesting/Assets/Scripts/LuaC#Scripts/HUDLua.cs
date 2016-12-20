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
        if (state.GetTop() != 1 || state.GetTop() != 2)
        {
            _lua.SetTop(0);
            _lua.PushString("Invalid amount of parameters");

        }
        if (state.GetTop() == 1)
        {
            Canvas canvas = this.gameObject.AddComponent<Canvas>();
            Text text = canvas.gameObject.AddComponent<Text>();
            text.text = state.ToString(1);
        }
        else if (state.GetTop() == 2)
        {
            Canvas canvas = this.gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            RectTransform canvasTransform = this.GetComponent<RectTransform>();
            Text text = canvas.gameObject.AddComponent<Text>();
            text.text = state.ToString(1);
            canvasTransform.position = new Vector3((float)state.ToNumber(2), (float)state.ToNumber(3), (float)state.ToNumber(4));
            canvasTransform.sizeDelta = new Vector2((float)state.ToNumber(5), (float)state.ToNumber(6));
        }
        

        _lua.SetTop(0);
        _lua.PushString("HUD successfull");
        return 1;
    }

}
