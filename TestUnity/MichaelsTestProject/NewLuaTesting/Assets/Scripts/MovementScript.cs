using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct MovementData {
    public float speed;
    public float time;
    public Vector3 Direction;

};

public class MovementScript : MonoBehaviour {
    Rigidbody _rigidBody;
    List<MovementData> _movements = new List<MovementData>();
    string lastHit;
	// Use this for initialization
	void Awake () {
        if ( _rigidBody == null ) {
            _rigidBody = gameObject.GetComponent<Rigidbody>();
            if ( _rigidBody == null ) {
                _rigidBody = gameObject.AddComponent<Rigidbody>();
            }
        }
    }

    public void Init(float speed, Vector3 direction, float timeInSeconds ) {
        if ( _rigidBody == null ) {
            _rigidBody = gameObject.GetComponent<Rigidbody>();
            if ( _rigidBody == null ) {
                _rigidBody = gameObject.AddComponent<Rigidbody>();
            }
        }
        _rigidBody.useGravity = false;
        MovementData m = new MovementData();
        m.speed = speed;
        m.time = timeInSeconds;
        m.Direction = direction;
        _movements.Add(m);
    }

    void OncollisionEnter(Collider col) {
        if ( col.gameObject.tag == "MoveableObject" ) return;
        lastHit = col.gameObject.name;
        _movements.Clear();

    }

    void FixedUpdate() {
        Vector3 newVec = Vector3.zero;
        //newVec.y = _rigidBody.velocity.y;
        int j = -1;
        for ( int i = 0; i < _movements.Count; i++ ) {
            MovementData m = _movements[i];
            newVec += m.Direction * m.speed ;
            m.time -= Time.fixedDeltaTime;
            if(m.time<0)j=i;
            _movements[i] = m;
            
        }

        if ( j > -1 ) {
            _movements.Remove(_movements[j]);
        }

        
        _rigidBody.velocity = newVec;
    }
}
