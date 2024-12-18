
using UnityEngine;
using Unity.Netcode;
using System;

public class PlayerMovement : NetworkBehaviour {

    public float playerSpeed;
    public Camera Camera;

    Vector3 movementDirection;
    float moveHorizontalX = 0f;
    float moveVerticalY = 0f;
    SpriteRenderer sr;

    public Animator animator;

    private NetworkVariable<float> facingDirection = new NetworkVariable<float>(
        5f, NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner);

    /*    public void Awake() { // turetume overridinti OnNetworkSpawn() vietoj start arba awake metodu, nereiks Awake()
        }*/


    public override void OnNetworkSpawn() {
        if (!IsOwner) {
            return;
        }
        sr = GetComponent<SpriteRenderer>();
        Camera = Camera.main;
        Camera.GetComponent<CameraFollow>().target = transform;
        animator = GetComponent<Animator>();


    }



    public void FixedUpdate() {

        if (!IsOwner) {
            return;
        }

        // Move();

        moveHorizontalX = Input.GetAxisRaw("Horizontal");
        moveVerticalY = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(moveHorizontalX, moveVerticalY, 0).normalized;
        transform.position += (movementDirection * playerSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontalX * playerSpeed));


        if (movementDirection.x > 0) {
            animator.SetBool("MoveToLeft", false);
            animator.SetBool("MoveToRight", true);

            facingDirection.Value = -Mathf.Abs(gameObject.transform.localScale.x);

        }
        else if (movementDirection.x < 0) {
            animator.SetBool("MoveToRight", false);
            animator.SetBool("MoveToLeft", true);

            facingDirection.Value = Mathf.Abs(gameObject.transform.localScale.x);

        }

    }
    public void Update() {
        // Apply the synchronized facing direction
        gameObject.transform.localScale = new Vector3(facingDirection.Value, transform.localScale.y, transform.localScale.z);
    }

}