using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyForce : MonoBehaviour
{
    float slideSpeed = 50f;

    //While the player is in collision with the trigger, move him away from the enemy
    private void OnTriggerStay(Collider other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            if (controller.velocity.magnitude < 0.1f)
            {
                Vector3 dir = other.transform.position - transform.position;
                if (dir.x == 0 && dir.z == 0)
                    dir = other.transform.forward;
                controller.SimpleMove(dir * slideSpeed * Time.deltaTime);
            }
        }
    }

}
