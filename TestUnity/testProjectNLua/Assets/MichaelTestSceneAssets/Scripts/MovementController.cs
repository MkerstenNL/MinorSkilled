using UnityEngine;
using System.Collections;

public class MovementController : ScriptableObject {

    public void Move(Transform obj, Vector3 newPos, bool local = false) {
        if ( local ) {
            obj.localPosition = newPos;

        } else {
            obj.position = newPos;

        }
    }

    public void Rotate(Transform obj, Vector3 newRot, bool local = false) {
        if ( local ) {
            obj.localEulerAngles = newRot;
        } else {
            obj.eulerAngles = newRot;
        }
    }
}
