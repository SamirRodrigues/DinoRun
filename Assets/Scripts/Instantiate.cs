using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    //Variável para controlar o spawner
    public bool Ative = true;

    public Rigidbody2D body1;   // Prefab 1
    public Rigidbody2D body2;   // Prefab 2
    public Transform spawn1;    // Ponto de Spawn 1
    public Transform spawn2;    // Ponto de Spawn 2
         

    private IEnumerator Start()
    {
        // Uma rotina que vai executar paralelo ao main code
        yield return new WaitForSeconds(5); // Espera um tempo de 5 segundos para executar a próxima linha
        StartCoroutine(Instance()); // Chama a rotina assim que começar o jogo
    }

    //Responsável por instanciar os Prefabs nos pontos de Spawn
    IEnumerator Instance()
    {

        Choice();                                             // Spawna meus Prefabs de maneira randômica 
        float a = Random.Range(2f , 6f);                      // Cria um valor randomico entre 2 e 6
        yield return new WaitForSeconds(a);                   // Espera um tempo em segundo para poder executar a próxima linha, usando por base o valor criado na linha anterior

        StartCoroutine(Instance());                           // Chama novamente a função
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Ative = !Ative;
        }

    }

    private void Choice()
    {
       
        if (Ative == true) {
            float c = Random.Range(1f, 3f); // Gera um número aleatório de 1 e 3

            if (c >= 1 && c <= 2) // Se criar um valor entre 1 e 2
            {
                Instantiate(body1, spawn1.position, spawn1.rotation); // Spawna Prefab 1
            }
            else // Se criar um valor maior que 2 e menor que 3
            {
                Instantiate(body2, spawn2.position, spawn2.rotation); // Spawna Prefab 2
            }

        }
    }
    
}
