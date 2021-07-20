using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public bool dead;
    public float x;
    public Vector3 p;
    public bool groundcheck;
    // Start is called before the first frame updateaaa
    void Start()
    {
        speed = 0.04f;
        p = this.gameObject.transform.position;
        x = 0;
        groundcheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        DeadCheck();
    }

    void Control()
    {

        if (Input.GetMouseButton(0))//left click
        {
            float speed = 0.5f;
            x = Input.GetAxis("Mouse X") * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundcheck == true)
        {
            Debug.Log("jump");
            groundcheck = false;
        }
    }

    private void DeadCheck()
    {
        if(p.y <= 0)
        {
            dead = true;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            dead = true;
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            groundcheck = true;
        }
    }

    void Test()
    {
        Debug.Log("");
        x = 0;
    }

}
