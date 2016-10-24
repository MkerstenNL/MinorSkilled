using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class ToolList : MonoBehaviour {

   [SerializeField] private List<ToolBase> tools = new List<ToolBase>();
    int id = 0;

    public ToolBase getNextTool() {
      //  Debug.Log(tools.Count+"      "+ id);
        tools[id].DeEquip();
        id = ( id + 1 ) % (tools.Count);
        tools[id].Equip();
        return tools[id];
    }



}
