using UnityEngine;
using System.Collections;

public class FlagVictory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision pOther)
    {
        if (pOther.transform.name == "Capsule")
        {
            Debug.Log("Good Job");
        }
    }
}
