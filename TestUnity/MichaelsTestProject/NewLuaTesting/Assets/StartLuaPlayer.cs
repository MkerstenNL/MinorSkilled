using UnityEngine;
using System.Collections;

public class StartLuaPlayer : MonoBehaviour {

    [SerializeField]bool OnTrigger = true;
    [SerializeField]
    Lualayer layer;

	// Use this for initialization
	void Start () {
        if (OnTrigger)return;
        layer.Init();
	}

    void OnTriggerEnter(Collider col) {
        if(!OnTrigger)return;
        layer.Init();

    }
	

}
