using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameInput : NetworkBehaviour
{
/*        moveHorizontalX = Input.GetAxisRaw("Horizontal");
        moveVerticalY = Input.GetAxisRaw("Vertical");*/

    public Vector2 getMovementVectorNormalized() {

        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        return inputVector;

    }

}
