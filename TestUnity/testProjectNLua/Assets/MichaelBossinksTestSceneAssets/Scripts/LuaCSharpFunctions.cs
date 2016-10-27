﻿using UnityEngine;
using System.Collections;
using NLua;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LuaCSharpFunctions : MonoBehaviour {

    private LuaObjectManager objectManager = new LuaObjectManager();

    public void SetPosition(int pX, int pY, int pZ)
    {
        this.transform.position = new Vector3(pX, pY, pZ);
    }
    public void SetRotation(int pX, int pY, int pZ)
    {
        this.transform.rotation = new Quaternion(pX, pY, pZ,0);
    }
    public void SetCollider(float pMass = 1, float pDrag = 0, float pAngularDrag = 0.5f, bool pUseGravity = true, bool pIsKinematic = false)
    {
        this.gameObject.AddComponent<Rigidbody>();
        if(this.gameObject.GetComponent<Collider>() is MeshCollider)
        {
            this.gameObject.GetComponent<MeshCollider>().convex = true;
        }
        if (pMass != 1)
        {
            this.gameObject.GetComponent<Rigidbody>().mass = pMass;
            this.gameObject.GetComponent<Rigidbody>().drag = pDrag;
            this.gameObject.GetComponent<Rigidbody>().angularDrag = pAngularDrag;
            this.gameObject.GetComponent<Rigidbody>().useGravity = pUseGravity;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = pIsKinematic;
        }
        //this.transform.position = new Vector3(pX, pY, pZ);
    }
    public void IsCollider(bool pYesNo)
    {
        this.GetComponent<Collider>().enabled = pYesNo;
    }
    public string IsCollider(string pYesNo)
    {
        pYesNo = pYesNo.ToLower();
        if (pYesNo == "y" || pYesNo == "yes" || pYesNo == "true")
        {
            this.GetComponent<Collider>().enabled = true;
            return "Collider is active";
        }
        else if (pYesNo == "n" || pYesNo == "no" || pYesNo == "false")
        {
            this.GetComponent<Collider>().enabled = false;
            return "Collider is not active";
        }
        else
        {
            return "Not an correct format. Choose Yes or No";
        }
    }
    public void SetColliderConstrains(bool pFreezeXPosition, bool pFreezeYPosition, bool pFreezeZPosition, bool pFreezeXRatation, bool pFreezeYRatation, bool pFreezeZRatation)
    {
        if (pFreezeXPosition)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
	    }
        if (pFreezeYPosition)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
	    }
        if (pFreezeZPosition)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
	    }
        if (pFreezeXRatation)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
	    }
        if (pFreezeYRatation)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
	    }
        if (pFreezeZRatation)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
	    }
    }
    public void SetColliderInterPolate(string pInterPolate = "1")
    {
        if (pInterPolate.ToLower() == "none" || pInterPolate == "1")
        {
            this.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
        }
        if (pInterPolate.ToLower() == "interpolate" || pInterPolate == "2")
        {
            this.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        }
        if (pInterPolate.ToLower() == "extrapolate" || pInterPolate == "3")
        {
            this.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Extrapolate;
        }
    }
    public void SetColliderCollisionDetection(string pCollisionDetection = "1")
    {
        if (pCollisionDetection.ToLower() == "discrete" || pCollisionDetection == "1")
        {
            this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
        if (pCollisionDetection.ToLower() == "continuous" || pCollisionDetection == "2")
        {
            this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        if (pCollisionDetection.ToLower() == "continuous dynamic" || pCollisionDetection.ToLower() == "continuousdynamic" || pCollisionDetection == "3")
        {
            this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }

    public void SetTexture(string pMaterial){
        Material material = Resources.Load("Materials/" + pMaterial) as Material;
        this.GetComponent<Renderer>().material = material;
    }

    public void AddBehaviour(string pName) {
        if(pName == null || pName =="")return;
        if ( !File.Exists(Environment.CurrentDirectory + "/Assets/Lua/" + pName + ".lua") )return;
        LuaBehaviour behaviour = gameObject.AddComponent<LuaBehaviour>();
        behaviour.source = LuaBehaviour.LoadLuaFile(pName);
        behaviour.filename = pName;

    }

    public LuaCSharpFunctions CreateObject(string pName) {
        GameObject prefab = Resources.Load(pName) as GameObject;
        //Debug.Log(prefab);
        GameObject _gameObject = (GameObject) GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        
        _gameObject.name = _gameObject.name.Replace("(Clone)", "");
        objectManager.AddObject(_gameObject);

        if ( _gameObject.GetComponent<Collider>() == null ) {
            _gameObject.AddComponent<MeshCollider>();
            _gameObject.GetComponent<MeshCollider>().convex = true;
        }
        if ( _gameObject.GetComponent<LuaCSharpFunctions>() == null ) {
            _gameObject.AddComponent<LuaCSharpFunctions>();
        }
        return _gameObject.GetComponent<LuaCSharpFunctions>();
    }

    public void Invalidate() {
        objectManager.ClearList();
    }
}
