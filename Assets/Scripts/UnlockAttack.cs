using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAttack : MonoBehaviour
{
    public Collider2D Collider; // Responsável por permitir editar o collider do Kick ou do HeadAttack   


    public void Start()
    {
        Collider = GetComponent<Collider2D>(); // Recebe o collider
        Collider.enabled = false;
    }

    public void AtiveAttack()
    {
        Collider.enabled = true;
    }

    public void DesativeAttack()
    {
        Collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Kill();
        }
    }
   
}
