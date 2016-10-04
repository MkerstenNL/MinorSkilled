using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class MainMenu : MonoBehaviour {

    [SerializeField]GameObject menu;
    [SerializeField]GameObject hud;
    [SerializeField]BehaviourManager manager;

    string saveName = "";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))showMainMenu();
	}

    private void showMainMenu() {
        if ( menu.activeInHierarchy == false ) {
            menu.SetActive(true);
            hud.SetActive(false);
            manager.Cancel();
            BehaviourManager.UsingHud = true;
        } else {
            menu.SetActive(false);
            BehaviourManager.UsingHud = false;
        }
    }

    public void Cancel() {
        BehaviourManager.UsingHud = false;
        menu.SetActive(false);
    }

    public void Load() {
        foreach ( IsClickedOnMouse destoryedGameObject in GameObject.FindObjectsOfType<IsClickedOnMouse>() ) {
            Destroy(destoryedGameObject.gameObject);
        }
        SaveCurrentScene.LoadJsonScene(saveName);
    }

    public void Save() {
        SaveCurrentScene.SaveJsonScene(GameObject.FindObjectsOfType<GameObject>().ToList(), saveName);
    }

    public void Quit() {
        Application.Quit();
    }
}
