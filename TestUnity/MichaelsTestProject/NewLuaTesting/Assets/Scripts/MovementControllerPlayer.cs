using UnityEngine;
using System.Collections;

public class MovementControllerPlayer : MonoBehaviour {
    [SerializeField]int _movementForce = 0;
    Rigidbody _rigidBody;
    [SerializeField]GameObject _cam;
    ProgrammingTool programmingTool;
    // Use this for initialization
    void Start() {
        _rigidBody = GetComponent<Rigidbody>();
        programmingTool = GetComponent<ProgrammingTool>();
    }

    void Update() {
        if(CanvasManager.UsingHud)return;
        rotate();
        mouseInput();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(CanvasManager.UsingHud)return;
        movement();
        
        
    }

    void movement() {
        _rigidBody.velocity = Vector3.zero;
        if ( Input.GetKey(KeyCode.W) ) {
            _rigidBody.velocity += transform.forward * _movementForce / 60;
        } else if ( Input.GetKey(KeyCode.S) ) {
            _rigidBody.velocity += transform.forward*-0.5f * _movementForce / 60;
        }

        if ( Input.GetKey(KeyCode.A) ) {
            _rigidBody.velocity += transform.right*-0.5f * _movementForce / 60;
        } else if ( Input.GetKey(KeyCode.D) ) {
            _rigidBody.velocity += transform.right*0.5f* _movementForce / 60;
        }
    }

    void rotate() {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        _cam.transform.Rotate(-1*y,0, 0);
        transform.Rotate(0, x, 0);
        if ( _cam.transform.rotation.eulerAngles.x > 60&& _cam.transform.rotation.eulerAngles.x <120 ) {
            _cam.transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
        } else if ( _cam.transform.rotation.eulerAngles.x < 300 && _cam.transform.rotation.eulerAngles.x > 120 ) {
            _cam.transform.rotation = Quaternion.Euler(new Vector3(300, 0, 0));
        }
    }

    void mouseInput() {
        if ( Input.GetMouseButtonDown(0) ) {
            programmingTool.Activate(this.gameObject);
        }

    }
}
