using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardObject : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        type = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        TypeMove(type);

    }

    public void TypeMove(int a)
    {
        if (a == 1)
        {
            this.gameObject.transform.Rotate(0, 0, 1);
        }

        if (a == 2)
        {
            this.gameObject.transform.Rotate(1, 0, 0);
            this.gameObject.transform.localScale = new Vector3(5, 5, 1);
        }

        if (a == 3)
        {
            this.gameObject.transform.Rotate(0, 1, 0);
            this.gameObject.transform.localScale = new Vector3(7, 5, 1);
        }
    }
}
    
   


