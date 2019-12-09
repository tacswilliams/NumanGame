using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public Rigidbody rb;
    public Playercolleshion pc;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<Playercolleshion>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
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


