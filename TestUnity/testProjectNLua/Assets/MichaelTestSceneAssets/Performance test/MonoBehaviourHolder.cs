using UnityEngine;
using System.Collections;

public class MonoBehaviourHolder : MonoBehaviour {

    MonoBehaviourStressTest s;
	// Use this for initialization
	void Start () {
        s = gameObject.AddComponent<MonoBehaviourStressTest>();
	}
	
	// Update is called once per frame
	void Update () {
        s.HeavyCalc();
	}
}
