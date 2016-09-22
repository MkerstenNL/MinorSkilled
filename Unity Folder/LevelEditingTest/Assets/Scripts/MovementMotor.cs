using UnityEngine;
using System.Collections;

public class MovementMotor : ScriptableObject {

    public enum Direction {
        Forward = 0,
        Backwards = 1,
        Left = 2,
        Right = 3,
    };

    public void Move(Direction pDirection,Transform pTrans, float movespeed) {
        switch ( pDirection ) {
            case Direction.Forward:
                pTrans.position += pTrans.forward* movespeed * Time.deltaTime;
            break;
                
            case Direction.Backwards:
                pTrans.position += pTrans.forward *-1* movespeed * Time.deltaTime;
            break;
                
            case Direction.Left:
                pTrans.position += pTrans.right*-1 * movespeed * Time.deltaTime;
            break;

            case Direction.Right:
            pTrans.position += pTrans.right * movespeed * Time.deltaTime;
            break;

            default:
                Debug.Log("Invalid direction");
            break;

        }
    }


}
