
using UnityEngine;

public class Playercolleshion : MonoBehaviour
{
    public PlayerMovement movement;
    public bool groundHit = false;
    public bool obstacleHit = false;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            obstacleHit = true;
            //movement.enabled = false;

        }
        if (collisionInfo.collider.tag == "Ground")
        {
            groundHit = true;
        }



    }
    
  } 

