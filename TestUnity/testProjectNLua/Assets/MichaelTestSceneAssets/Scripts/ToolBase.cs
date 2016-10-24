using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class ToolBase : MonoBehaviour {
    public abstract void Activate(GameObject obj);
    public abstract void DeActivate();
    public abstract void Equip();
    public abstract void DeEquip();

}
