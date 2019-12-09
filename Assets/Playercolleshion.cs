
using UnityEngine;

public class Playercolleshion : MonoBehaviour
{
    public PlayerMovement movement;
    public bool groundHit = false;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {

            //movement.enabled = false;

        }
        if (collisionInfo.collider.tag == "Ground")
        {
            groundHit = true;
        }



    }
    
  } 

