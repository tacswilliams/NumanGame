using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Playercolleshion pc;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    private Vector3 position;
    public float width;
    public float height;


    public float timer = 0f;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<Playercolleshion>();
        width = (float)Screen.width;
        height = (float)Screen.height;

        position = new Vector3(0.0f, 0.0f, 0.0f);

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
        if (timer > 1)
        {
            timer = 0f;
            pc.obstacleHit = false;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -10;
        // multiply the x values by -1 to correctly map the cursor position
        // instead of direct mapping, lerp player to cursor's x position
        Debug.Log("Mouse Pos: " + Camera.main.ScreenToWorldPoint(mousePos));
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(mousePos);


        if (pc.groundHit)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
           // Vector3 newPos = new Vector3(mousepos.x * -1, transform.position.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);

            /*
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            }
            */

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    pos.x = (pos.x - width) / width;
                    pos.y = (pos.y - height) / height;
                    position = new Vector3(pos.x.Remap(-1,0,-12,12), transform.position.y, transform.position.z);

                    transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
                }


            }
        }
    }
}

public static class ExtensionMethods {
 
public static float Remap (this float value, float from1, float to1, float from2, float to2) {
    return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
}
   
}
