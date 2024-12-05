
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour {

    public float playerSpeed;
    public Camera Camera;

    Vector3 movementDirection;
    float horizontalMoveX = 0f;
    float verticalMoveY = 0f;
    SpriteRenderer sr;

    public Animator animator;

    public void Awake() { // turetume overridinti OnNetworkSpawn() vietoj start arba awake metodu, nereiks Awake()
    }


    public override void OnNetworkSpawn() {
        if (!IsOwner) {
            return;
        }
        sr = GetComponent<SpriteRenderer>();
        Camera = Camera.main;
        Camera.GetComponent<CameraFollow>().target = transform;

    }



public void FixedUpdate() {

        if (!IsOwner) {
            return;
        }

        horizontalMoveX = Input.GetAxisRaw("Horizontal");
        verticalMoveY = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(horizontalMoveX, verticalMoveY, 0).normalized;
        transform.position += (movementDirection * playerSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoveX * playerSpeed));

        if (movementDirection.x > 0) {
            sr.flipX = true;

        }
        else if (movementDirection.x < 0) {
            sr.flipX = false;
        }

    }
}