using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlickAnim : MonoBehaviour
{
    public Renderer Object;
    
    public void Blink()
    {
        Object.enabled = false;
    }
}
