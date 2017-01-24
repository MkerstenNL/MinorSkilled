using UnityEngine;
using System.Collections;

public class StartLuaPlayer : MonoBehaviour {

    [SerializeField]bool OnTrigger = true;
    [SerializeField]
    TopLevelLua layer;

    public string Layername { get { return layer.name; } }

    // Use this for initialization
    void Start () {
        if (OnTrigger)return;
        layer.Init();
        Debug.Log(layer.GetFile()+"dsfdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
	}

    void OnTriggerEnter(Collider col) {
        if(!OnTrigger|| col.gameObject.tag!="Player")return;
        layer.Init();

    }
}
