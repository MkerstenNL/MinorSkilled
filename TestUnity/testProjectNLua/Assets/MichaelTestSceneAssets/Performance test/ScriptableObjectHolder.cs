using UnityEngine;
using System.Collections;

public class ScriptableObjectHolder : MonoBehaviour {
    ScriptableObjectPerformanceTest s;
	// Use this for initialization
	void Start () {
        s = ScriptableObject.CreateInstance<ScriptableObjectPerformanceTest>();
	}
	
	// Update is called once per frame
	void Update () {
        s.HeavyCalc();
	}
}
