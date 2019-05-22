using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliser : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D AnotherObj)
    {
        if (AnotherObj.gameObject.CompareTag("Enemy"))
        {
            Destroy(AnotherObj.gameObject);
            Destroy(gameObject);

        }
       
                
    }
}
