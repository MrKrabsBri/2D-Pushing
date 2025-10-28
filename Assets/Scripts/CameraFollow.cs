
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;// = 5f; // Speed at which the camera moves towards the target

    void FixedUpdate() {
        if (target == null) {
            return;
        }

        // Move the camera towards the target
        Vector3 direction = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // buvo Time.deltaTime Time.fixedDeltaTime Runner.DeltaTime

        // Optionally, adjust the camera's z-position to keep it at a fixed distance from the player
        transform.position = new Vector3(transform.position.x, transform.position.y, -10); // Adjust the -10 value as needed
    }
}
