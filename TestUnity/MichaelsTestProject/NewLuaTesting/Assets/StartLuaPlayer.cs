using UnityEngine;
using System.Collections;

public class StartLuaPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Lualayer>().Init();
	}
	

}
