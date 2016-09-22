using UnityEngine;
using System.Collections;

public class InputClass : MonoBehaviour {

    private MovementMotor _movement;
    [SerializeField] private KeyCode Forward;
    [SerializeField] private KeyCode BackWards;
    [SerializeField] private KeyCode Left;
    [SerializeField] private KeyCode Right;
    [SerializeField] private KeyCode nextItem;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject cam;
    private Vector2 _oldMousePos;

    // Use this for initialization
    void Start () {
        _movement = ScriptableObject.CreateInstance<MovementMotor>();
        _oldMousePos = Input.mousePosition;
        
	}
	
	// Update is called once per frame
	void Update () {
        movement();
        rotation();
        toolSelection();

	}

    private void movement() {
        if ( Input.GetKey(Forward) ) {
            _movement.Move(MovementMotor.Direction.Forward, transform, moveSpeed);
        }
        if ( Input.GetKey(BackWards) ) {
            _movement.Move(MovementMotor.Direction.Backwards, transform, moveSpeed);
        }
        if ( Input.GetKey(Left) ) {
            _movement.Move(MovementMotor.Direction.Left, transform, moveSpeed);
        }
        if ( Input.GetKey(Right) ) {
            _movement.Move(MovementMotor.Direction.Right, transform, moveSpeed);
        }
    }

    private void rotation() {
        Vector2 newPos = Input.mousePosition;
        Vector2 diff = _oldMousePos - newPos;
        diff.Normalize();
        this.transform.eulerAngles += new Vector3(0, diff.x*-1 * rotationSpeed,0);


        float newRotx = cam.transform.eulerAngles.x + (diff.y * rotationSpeed);
        if(newRotx>90&&newRotx<200)newRotx = 90;
        if(newRotx<270&&newRotx>200)newRotx = 270;
        cam.transform.localEulerAngles = new Vector3(newRotx, 0, 0);
        
        _oldMousePos = newPos;
    }

    private void toolSelection() {
        float up = Input.GetAxis("Mouse ScrollWheel");

    }
}
