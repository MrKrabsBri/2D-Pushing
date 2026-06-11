using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Netcode;
using UnityEngine;


public class Player : NetworkBehaviour {

    public float maxHitpoints = 5f;
    public float currentHitpoints = 5f;
    public float damageValue = 1f;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;
    public float attackCooldown = 1f; // Cooldown time in seconds, weapon speed.
    public Monster monsterBat;

    public void takeDamage(float damage) {
        currentHitpoints -= damage;
        Debug.Log("Current hitpoints of Player: " + currentHitpoints);
        if (currentHitpoints <= 0) {
            GetComponent<NetworkObject>().Despawn();
        }
        //if hp <=0 , die
    }

    void Awake() {
        monsterBat = GameObject.Find("Enemy_Bat").GetComponent<Monster>();
        Debug.Log("found a monster: " + monsterBat.name);
    }

    void Update() {

        if (!IsOwner) return ;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastAttackTime 
            + attackCooldown && !isAttacking) {
           // performAttack();
            lastAttackTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            // monsterBat.destroyThisMonster();
            DestroyMonsterServerRpc();
        }

    }

    //on weapon swing check if there is a collision with an enemy,
    //if so, call the takeDamage function of the enemy and pass the damage
    //value of the weapon as a parameter
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<Monster>()?.takeDamage(damageValue); // Example damage value
        collision.gameObject.GetComponent<BatNonNetworked>()?.takeDamage(damageValue);
    }

    //---------------------------- RPCS -----------------------------
    [ServerRpc]
    private void DestroyMonsterServerRpc() {
        monsterBat.destroyThisMonster();
    }


    /*     [ServerRpc]
    private void DestroyMonsterServerRpc()
    {
        monsterBat.destroyThisMonster();
    }


        [ServerRpc]
    private void DestroyMonsterServerRpc()
    {
        monsterBat.destroyThisMonster();
    }

    [ServerRpc]
    void performAttackServerRpc(ServerRpcParams serverRpcParams) {
        performAttackClientRpc();
    }

    [ClientRpc]
    void performAttackClientRpc() {
        // All clients (including sender) show jump
        Debug.Log("A client clicked Attack, All clients are shown the Attack");
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("IsAttacking");
    }*/
}


