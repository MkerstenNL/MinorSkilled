using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputClass : MonoBehaviour {
    [SerializeField] private KeyCode Forward;
    [SerializeField] private KeyCode Backward;
    [SerializeField] private KeyCode Left;
    [SerializeField] private KeyCode Right;

    MovementController controller;
    GameObject cam;
    [SerializeField]PlayerData _playerStats;
    // Use this for initialization


   
    ToolBase _currentTool;
    [SerializeField]private ToolList _tools;

    float Rotx =0;
    float Roty = 0;
    
	void Start () {
        if(_playerStats==null)_playerStats = ScriptableObject.CreateInstance<PlayerData>();
        controller = ScriptableObject.CreateInstance<MovementController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        _currentTool = _tools.getNextTool();
	}
	
	// Update is called once per frame
	void Update () {
        if(BehaviourManager.UsingHud)return;
        handleMovementInput();
        handleRotationInput();
        handleToolInput();
	
	}

    private void handleMovementInput() {
        if ( Input.GetKey(Forward) )controller.Move(this.transform, this.transform.position+transform.forward*Time.deltaTime*_playerStats.MovementSpeed) ;
        if ( Input.GetKey(Backward) )controller.Move(this.transform, this.transform.position+transform.forward*-1*Time.deltaTime*_playerStats.MovementSpeed) ;
        if ( Input.GetKey(Right) )controller.Move(this.transform, this.transform.position+transform.right*Time.deltaTime*_playerStats.MovementSpeed) ;
        if ( Input.GetKey(Left) )controller.Move(this.transform, this.transform.position+transform.right*-1*Time.deltaTime*_playerStats.MovementSpeed) ;
    }

    private void handleRotationInput() {
        Rotx += Input.GetAxis("Mouse X");
        Roty -= Input.GetAxis("Mouse Y");
        if ( Roty < -45 ) {
            Roty = -45;
        } else if ( Roty > 45 ) {
            Roty = 45;
        }
        controller.Rotate(cam.transform, new Vector3(Roty, 0, 0),true);
        controller.Rotate(transform, new Vector3(0, Rotx, 0));
    }

    private void handleToolInput() {
        if(Input.GetMouseButtonDown(0))_currentTool.Activate(cam);
        if(Input.GetMouseButtonDown(1))_currentTool.DeActivate();
        if(Input.GetKeyDown(KeyCode.E))_currentTool = _tools.getNextTool();
    }

   /* void OnGUI() {
        GUI.TextField(new Rect(0, 0, 300, 25), "CurrentTool: " + _currentTool.ToString());
    }*/
}
