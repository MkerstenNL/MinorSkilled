using UnityEngine;
using System.Collections;

public class WaterDeathScript : MonoBehaviour {
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("SapphiArtchan");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == player.gameObject.name)
        {
            player.transform.position = new Vector3(14, 6, 17);
        }
    }
}
