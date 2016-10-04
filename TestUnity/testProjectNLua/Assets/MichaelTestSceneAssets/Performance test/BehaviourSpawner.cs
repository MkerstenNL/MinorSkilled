using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviourSpawner : MonoBehaviour {

    List<GameObject> go = new List<GameObject>();

	// Use this for initialization
	void Start () {
        for ( int i = 0; i < 1000; i++ ){
            GameObject g = new GameObject();
            //g.AddComponent<MonoBehaviourHolder>();
            g.AddComponent<ScriptableObjectHolder>();
            go.Add(g);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
