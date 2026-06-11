using UnityEngine;

public class BatNonNetworked : MonoBehaviour
{
    public float maxHitpoints = 10f;
    public float currentHitpoints = 10f;
    public float damageValue = 3f;
    //TODO: add damage calc mechanics

    /*        
    ---  kad atskirti kai multiplayer----
        NetworkBehaviour networkBehaviour = collision.gameObject.GetComponent<NetworkBehaviour>();
        if (networkBehaviour != null && networkBehaviour.IsOwner) {
            // Hit YOUR player only
        }
    */

    public void takeDamage(float amount) {
        currentHitpoints -= amount;
        Debug.Log("Current hitpoints of Monster: " + currentHitpoints);
        if (currentHitpoints <= 0) {
            die();
        }
    }

    public virtual void die() {
        Destroy(gameObject);
        //drop loot, play animation, etc.
    }

    public virtual void Attack() {
        // Base attack logic
    }
}
