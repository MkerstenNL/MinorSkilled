using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour {
    [SerializeField]InputField _input;
    int timer = 0;
    // Use this for initialization
	void Awake () {
        timer = 100;
	}

    public void SetMessage(string message) {
        gameObject.SetActive(true);
        _input.GetComponentInChildren<Text>().text = message;
        timer = 600;
    }

	// Update is called once per frame
	void Update () {
        timer--;
        if ( timer < 0 ) {
            gameObject.SetActive(false);
        }
	}
}
