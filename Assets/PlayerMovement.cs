using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public Rigidbody rb;
    public Playercolleshion pc;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    
    public float timer = 0f;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<Playercolleshion>();
    }

    public void ResetPlayer()
    {
        //roatation
        

        //postition


        //ground hit false

    }
    
        
    

    // Update is called once per frame
    void FixedUpdate() 
    {
        // repositions player to face front bsed on a timer
        if (pc.obstacleHit && timer < 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, timer);
            timer = timer + Time.deltaTime;

        }

        // Resets the timer and obstacle hit variable
        if(timer > 1)
        {
            timer = 0f;
            pc.obstacleHit = false;
        }

        if (pc.groundHit) {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);


            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            }
        }
    }
}


