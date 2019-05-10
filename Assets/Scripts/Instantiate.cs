using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Rigidbody2D body1;
    public Rigidbody2D body2;
    public Transform spawn1;
    public Transform spawn2;


    private float count = 0;

    void Update()
    {
        
        count += 1f;

        //Debug.Log(count);
        if (Mathf.Abs(count) == 500)
        {
            Instantiate(body1,spawn1.position, spawn1.rotation);
                       
        }
        if (Mathf.Abs(count) == 300)
        {
            Instantiate(body2, spawn2.position, spawn2.rotation);

        }

        if(count > 1000)
        {
            count = 0;
        }
    }
}
