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
        transform.rotation = Quaternion.identity;

        //postition
        transform.position = new Vector3(0, 5, -6);

        //ground hit false
        pc.groundHit = false;
        
   
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        

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

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -10;
        // multiply the x values by -1 to correctly map the cursor position
        // instead of direct mapping, lerp player to cursor's x position
        Debug.Log("Mouse Pos: " + Camera.main.ScreenToWorldPoint(mousePos));

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


