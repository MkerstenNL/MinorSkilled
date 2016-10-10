using UnityEngine;
using System.Collections;
using NLua;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LuaCSharpFunctions : MonoBehaviour {

    public void SetPosition(int pX, int pY, int pZ)
    {
        this.transform.position = new Vector3(pX, pY, pZ);
    }
    public Vector3 GetPosition()
    {
        return this.transform.position;
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

    public void SetTexture(string pMaterial)
    {
        Texture material = Resources.Load(Environment.CurrentDirectory + "/Assets/MichaelBossinksTestSceneAssets/Materials/" + pMaterial) as Texture;
        this.GetComponent<Renderer>().material.mainTexture = material;
    }

    public bool TurnColliderOn(bool pOnOff)
    {
        if (pOnOff)
        {
            if (!this.GetComponent<Rigidbody>())
            {
                this.gameObject.AddComponent<Rigidbody>(); 
            }
            return true;
        }
        else
        {
            if (this.GetComponent<Rigidbody>())
            {
                Destroy(this.GetComponent<Rigidbody>());
            }
            return false;
        }
    }
    public void Transparency(float pTrans = 1)
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f,pTrans);
    }
    public float GetRandomFloat(float pMinRange=0, float pMaxRange=99999999)
    {
        return UnityEngine.Random.RandomRange(pMinRange, pMaxRange);
    }
    public float GetRandomInt(int pMinRange = 0, int pMaxRange = 99999999)
    {
        return UnityEngine.Random.Range(pMinRange, pMaxRange);
    }
    public void Message(string pMessage)
    {

    }
    public void Deadly(bool pIsInstantDeath, float pMinHP)
    {

    }
    public void OnOff(bool pIsOn, GameObject pGameObject)
    {

    }
}
