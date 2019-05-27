using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float vel = 8f; // Velocidade que a madeira irá se mover
 
    private void Update()
    {
        Move();
    }


    public void Move() // Irá controlar os movimentos do personagem
    {

        transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0)); // Move o Enemy para esquerda

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Caso um objeto com tag Player entre no meu trigger
        {
           collision.GetComponent<PlayerAnim>().TopadaAnim();
        }
        if (collision.gameObject.CompareTag("WoodDestroyer")) // Caso um objeto com tag Player entre no meu trigger
        {
            Destroy(gameObject);
        }
    }
}