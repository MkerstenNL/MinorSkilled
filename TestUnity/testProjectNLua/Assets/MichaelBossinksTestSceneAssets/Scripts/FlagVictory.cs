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
        Debug.Log(pOther.transform.name);
        if (pOther.transform.name == "Player")
        {
            Debug.Log("Good Job");
        }
    }
}
