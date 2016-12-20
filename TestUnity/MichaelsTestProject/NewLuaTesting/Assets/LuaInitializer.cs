using UnityEngine;
using System.Collections;

public class LuaInitializer : MonoBehaviour {
    [SerializeField]CanvasManager cm;

    void OnTriggerEnter(Collider col) {
        if ( col.gameObject.tag == "Player" ) {
            cm.LoadScript(GetComponent<TopLevelLua>());
        }
    }
}
