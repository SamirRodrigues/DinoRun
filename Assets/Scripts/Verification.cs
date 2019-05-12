using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verification : MonoBehaviour
{
    private float vel = 3;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));
    }
}
