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
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(CanvasManager.UsingHud)return;
        movement();
        
        
    }

    void movement() {
        if ( Input.GetKey(KeyCode.W) ) {
            _rigidBody.AddForce(transform.forward * _movementForce);
        } else if ( Input.GetKey(KeyCode.S) ) {
            _rigidBody.AddForce(transform.forward*-0.5f * _movementForce);
        }

        if ( Input.GetKey(KeyCode.A) ) {
            _rigidBody.AddForce(transform.right*-0.5f * _movementForce);
        } else if ( Input.GetKey(KeyCode.D) ) {
            _rigidBody.AddForce(transform.right*0.5f* _movementForce);
        }

        if ( Input.GetKeyDown(KeyCode.Space) ) {
            _rigidBody.AddForce(Vector3.up * 5000);
        }
    }

    void rotate() {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //_cam.transform.Rotate(-1*y,0, 0);
        transform.Rotate(0, x, 0);
        //if ( _cam.transform.rotation.eulerAngles.x > 60&& _cam.transform.rotation.eulerAngles.x <120 ) {
        //    _cam.transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
        // if ( _cam.transform.rotation.eulerAngles.x < 300 && _cam.transform.rotation.eulerAngles.x > 120 ) {
         //   _cam.transform.rotation = Quaternion.Euler(new Vector3(300, 0, 0));
       // }
    }
}
