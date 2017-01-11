using UnityEngine;
using System.Collections;
using System;
using UniLua;
using System.Collections.Generic;

public class RigidBodyLink : LuaLink {
    MovementScript _movement;
    Rigidbody _rigidBody;
    void awake() {
        scriptName = "RigidBody";
        scriptLocation = "Engine";
        _movement = gameObject.AddComponent<MovementScript>();

    }

    public override void init(ILuaState state) {
        if ( !gameObject.GetComponent<Rigidbody>() ) {
            _rigidBody = gameObject.AddComponent<Rigidbody>();
        }
        scriptName = "RigidBody";
        scriptLocation = "Engine";
        base.init(state);
    }

    protected override void registerFunctions() {
        regFunction("RigidBodyC", "Log",            Log);
        regFunction("RigidBodyC", "IsMoving",       IsMoving);
        regFunction("RigidBodyC", "GetDirection",   GetDirection);
        regFunction("RigidBodyC", "Move",           Move);
        regFunction("RigidBodyC", "MoveToTarget",   MoveToTarget);
        regFunction("RigidBodyC", "UseGravity",     UseGravity);
        regFunction("RigidBodyC", "GetPosition",    GetPosition);
        regFunction("RigidBodyC", "TurnOnCollider", TurnOnCollider);
        foreach ( KeyValuePair<string, List<NameFuncPair>> lib in _libs ) {
            _lua.L_NewLib(lib.Value.ToArray());
            _lua.SetGlobal(lib.Key);
        }
    }

    public int IsMoving(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            state.SetTop(0);
            _lua.PushString("Invalid amount of parameters");
            return 1;
        }
        float mag = _rigidBody.velocity.magnitude;
        bool val = mag > 0 ? true : false;
        _lua.PushBoolean(val);
        return 1;
    }

    public int GetDirection(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            _lua.SetTop(0);
            _lua.PushString("Incorrect number of arguments. function requires 0");
            return 1;
        }
        Vector3 dir = Vector3.zero;
        switch ( state.ToString(-1) ) {
            case "Up":
            dir = Vector3.up;
            break;

            case "Down":
            dir = Vector3.down;
            break;

            case "Left":
            dir = Vector3.left;
            break;

            case "Right":
            dir = Vector3.right;
            break;

            case "Forward":
            dir = Vector3.forward;
            break;

            case "Back":
            dir = Vector3.back;
            break;

            default:
            _lua.SetTop(0);
            _lua.PushString("invalid parameter");
            return 1;
        }
        _lua.SetTop(0);
        _lua.PushNumber(dir.x);
        _lua.PushNumber(dir.y);
        _lua.PushNumber(dir.z);
        return 3;
    }

    //direction speed time
    public int Move(ILuaState state) {
        if ( state.GetTop() != 5 ) {
            state.SetTop(0);
            _lua.PushString("Invalid amount of parameters");
            return 1;
        }
        float distance = (float) _lua.ToNumber(5);
        float speed = (float)_lua.ToNumber(4);
        float dirz = (float) _lua.ToNumber(3);
        float diry = (float) _lua.ToNumber(2);
        float dirx = (float) _lua.ToNumber(1);
        float time = distance / (speed);
        if(_movement==null)_movement = gameObject.AddComponent<MovementScript>();
        _movement.Init(speed, new Vector3(dirx,diry,dirz), time);
        _lua.SetTop(0);
        _lua.PushString("Operation succesful");
        return 1;
    }

    public int MoveToTarget(ILuaState state) {
        if ( state.GetTop() != 4 ) {
            state.SetTop(0);
            _lua.PushString("Invalid amount of parameters");
            return 1;
        }
        float speed = (float) _lua.ToNumber(-4);
        float posz = (float) _lua.ToNumber(-3);
        float posy = (float) _lua.ToNumber(-2);
        float posx = (float) _lua.ToNumber(-1);
        Vector3 targetPos = new Vector3(posx, posy, posz);
        float distance = (this.transform.position - targetPos).magnitude;
        float time = distance / speed;
        if ( _movement == null )
            _movement = gameObject.AddComponent<MovementScript>();
        _movement.Init(speed, (targetPos - transform.position).normalized, time);
        _lua.SetTop(0);
        _lua.PushString("Operation succesful");
        return 1;
    }

    public int UseGravity(ILuaState state) {
        if ( state.GetTop() != 1 ) {
            state.SetTop(0);
            _lua.PushString("Invalid amount of parameters");
            return 1;
        }
        bool gravity = _lua.ToBoolean(1);
        _rigidBody.useGravity = gravity;
        _lua.SetTop(0);
        _lua.PushString("Gravity:" + gravity.ToString());
        return 1;
    }

    public int GetPosition(ILuaState state) {
        if ( state.GetTop() != 0 ) {
            _lua.SetTop(0);
            state.PushString("Invalid amount of parameters. function requires 0");
            return 1;
        }
        _lua.PushNumber(this.transform.position.x);
        _lua.PushNumber(this.transform.position.y);
        _lua.PushNumber(this.transform.position.z);
        return 3;
    }

    public int TurnOnCollider(ILuaState state)
    {
        if (state.GetTop() != 1)
        {
            _lua.SetTop(0);
            state.PushString("Invalid amount of parameters. function requires 0");
            return 1;
        }

        _rigidBody.gameObject.GetComponent<Collider>().isTrigger = _lua.ToBoolean(-1);
        return 0;
    }

}
