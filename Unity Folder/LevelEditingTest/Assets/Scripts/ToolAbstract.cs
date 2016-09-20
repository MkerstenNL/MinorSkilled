using UnityEngine;
using System.Collections;

public abstract class ToolAbstract : ScriptableObject {

    public abstract void OnEquip();
    public abstract void OnDequip();
    public abstract void Activate();
    public abstract void DeActivate();
}
