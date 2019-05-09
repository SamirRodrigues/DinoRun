using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLook : MonoBehaviour
{

    //Função flip, nesse código, aplicada ao jogador, tem por finalidade verificar para qual lado o personagem está se dirigindo e em seguida girar a imagem par ao lado correto
    public bool face = true;
    public Transform playerX;

    void Start()
    {
        playerX = GetComponent<Transform>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !face)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && face)
        {
            Flip();
        }
    }

    void Flip()
    {
        face = !face;

        Vector3 scala = playerX.localScale;
        scala.x *= -1;
        playerX.localScale = scala;
    }
}
