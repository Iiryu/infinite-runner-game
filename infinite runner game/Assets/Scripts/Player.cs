using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float x;
    public Vector3 p;
    public bool groundcheck;
    public GameObject player;
    public bool stop;
    public float sens;
    public Manager m;
    
    // Start is called before the first frame updateaaa
    void Start()
    {
        speed = 5f;
        x = 0;
        groundcheck = true;
        stop = false;
        sens = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        DeadCheck();
        Dead();
        if (stop == false)
        {
            Control();
            Gravity();
        }
    }

    void Control()
    {
        transform.position += transform.forward * 10 * Time.deltaTime;

        if (Input.GetMouseButton(0))//left click
        {
            x = Input.GetAxis("Mouse X");
            transform.position += transform.right * speed * sens * Time.deltaTime * x;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundcheck == true)
        {
            Jump();
        }
    }

    private void DeadCheck()
    {
        if(this.gameObject.transform.position.y < -1)
        {
            m.gameOver = true;
        }
        
    }

    private void Dead()
    {
        if(m.gameOver == true)
        {
            stop = true;
            this.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void Gravity()
    {
        if(groundcheck == false)
        {
            float grabity = 3f;
            transform.position += transform.up * -grabity * Time.deltaTime;
        }
    }

    public void Jump()
    {
        transform.Translate(0, 0, 0);
        Debug.Log("jump");
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            m.gameOver = true;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundcheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundcheck = false;
        }
    }

    void Test()
    {
        Debug.Log("");
        x = 0;
    }

    

    

}
