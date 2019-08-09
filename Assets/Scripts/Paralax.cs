using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Vector3 limit;
    [SerializeField] private float speed;

    [Header("Images")]
    [SerializeField] private List<GameObject> images;

    private float spriteSize;

    private bool paused = false;

    private void Awake()
    {
        spriteSize = images[0].GetComponent<SpriteRenderer>().size.x * images[0].transform.localScale.x;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.localPosition = images[i].transform.localPosition + new Vector3(-1 * speed * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void LateUpdate()
    {
        
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].transform.localPosition.x <= limit.x)
            {
                if (i == images.Count - 1)
                {
                    images[i].transform.localPosition = images[0].transform.localPosition + new Vector3(spriteSize, 0, 0);
                }
                else
                {
                    images[i].transform.localPosition = images[i + 1].transform.localPosition + new Vector3(spriteSize, 0, 0);
                }
            }
        }
    }
}
