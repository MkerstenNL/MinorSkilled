using UnityEngine;
using System.Collections;

public class hitguardscript : MonoBehaviour {
    [SerializeField]Transform pos;
    void OnCollisionEnter(Collision other) {
        if ( other.gameObject.tag == "Guard" ) {
            this.transform.position = pos.position;
        }
    }
}
