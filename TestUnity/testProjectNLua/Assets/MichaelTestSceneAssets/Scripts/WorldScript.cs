using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldScript : MonoBehaviour {
    GameObject[] gameObjects;
	
    

    // Use this for initialization
	void Start () {
        gameObjects = this.gameObject.GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// refreshes the list of all gameobjects.
    /// </summary>
    public void Invalidate() {
        gameObjects = this.gameObject.GetComponentsInChildren<GameObject>();
    }

    /// <summary>
    /// activates all behaviours and lua scripts
    /// </summary>
    private void activateAll() {
        

    }

    /// <summary>
    /// resets all of the objects back to its original position
    /// </summary>
    private void reset() {


    }
}
