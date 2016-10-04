using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MovementBehaviour : CustomBehaviour {

    public enum Direction {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward,
        None
    }

    bool active = false;

	void Awake () {
        _name = "MovementBehaviour";
        variableList.Add("Speed", 0.0f);
        variableList.Add("Direction", Direction.None);
        
	}

    public override void Init() {
        active = true;

    }
	
	// Update is called once per frame
	void Update () {
	    if(!active)return;
        Vector3 dir = getDirection();
        this.transform.position += dir * Time.deltaTime;
	}

    private Vector3 getDirection() {
        Vector3 dir = Vector3.zero;
        object dirEnum;
        object speed;
        VariableList.TryGetValue("Speed", out speed);
        VariableList.TryGetValue("Direction", out dirEnum);
        switch ( (Direction) dirEnum ) {
            case Direction.Forward:
            dir = this.transform.forward*(float)speed;
            break;

            case Direction.Backward:
            dir = this.transform.forward * -1 * (float) speed;
            break;

            case Direction.Up:
            dir = this.transform.up * (float) speed;
            break;

            case Direction.Down:
            dir = this.transform.up * -1 * (float) speed;
            break;

            case Direction.Left:
            dir = this.transform.right * -1 * (float) speed;
            break;

            case Direction.Right:
            dir = this.transform.right * (float) speed;
            break;

            default:
            break;
        }


        return dir;
    }
}