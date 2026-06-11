using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class Monster : NetworkBehaviour {
    public float maxHitpoints;
    public float currentHitpoints;
    public float damageValue;
   //private NetworkVariable<bool> isDestroyed = new NetworkVariable<bool>(false);
    //TODO: add damage calc mechanics



    public virtual void takeDamage(float amount) {
        currentHitpoints -= amount;
        Debug.Log("Current hitpoints of Monster: " + currentHitpoints);
        if (currentHitpoints <= 0) {
            DestroyMonsterServerRpc();
        }
    }

    public virtual void destroyThisMonster() {
            DestroyMonsterServerRpc();
        

    }

    [ServerRpc]
    private void DestroyMonsterServerRpc() {
        // Server sets isDestroyed to true (syncs to all clients)
       // isDestroyed.Value = true;

        // Despawn the object
        GetComponent<NetworkObject>().Despawn(true);
    }
    /*
        [Rpc(SendTo.Server)]
        private void dieRpc() {
            die();
        }

        public virtual void die() {
            isDestroyed.Value = true;
            GetComponent<NetworkObject>().Despawn(true);
        }*/

    public virtual void attack() {
        // Base attack logic
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().hitpointsDamage(damageValue);
        }
    }*/
}
