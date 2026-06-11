using Unity.Netcode;
using UnityEngine;

public class MonsterBat : Monster
{
    /*public float maxHitpoints = 5f;
    public float currentHitpoints = 5f;
    public float damageValue = 1f; //(pvz 0-1)*/
    private NetworkVariable<bool> isDestroyed = new NetworkVariable<bool>(false);

   /* public override void OnNetworkSpawn() {
        base.OnNetworkSpawn();

        // Subscribe to changes in isDestroyed
        isDestroyed.OnValueChanged += OnDestroyedChanged;

        // Apply current state immediately
        if (isDestroyed.Value) {
            gameObject.SetActive(false);
        }
    }

    public override void OnNetworkDespawn() {
        isDestroyed.OnValueChanged -= OnDestroyedChanged;
        base.OnNetworkDespawn();
    }

    private void OnDestroyedChanged(bool oldValue, bool newValue) {
        if (newValue) {
            gameObject.SetActive(false);
        }
    }*/

    void Start() {
        // View the inherited value
        Debug.Log("Bat damage: " + damageValue);

        // Set the inherited value
        damageValue = 1.1f;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().takeDamage(damageValue);
        }
    }

}
