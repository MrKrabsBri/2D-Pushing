using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CollisionController : NetworkBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        // if (collision.gameObject.name == "Pond1" || collision.gameObject.name == "Pond2") {
        //(collision.gameObject.CompareTag(“tagName”){

        if (!IsOwner) return; // Ensure only the local player logs messages

        Debug.Log("Collided with:" + collision.gameObject.name);
       // }

    }
    private void OnTriggerEnter2D(Collider2D other) {

        if (!IsOwner) return;

        // uncomment veliau del testing purposes
       //Debug.Log("Triggered with: " + other.gameObject.name);
    }
}

