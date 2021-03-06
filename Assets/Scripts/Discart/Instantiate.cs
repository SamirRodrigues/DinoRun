﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    //Variável para controlar o spawner
    public bool Ative = true;

    public Rigidbody2D flyBody;   // Prefab 1
    public Rigidbody2D groundBody;   // Prefab 2
    public Rigidbody2D woodBody;   // Prefab 3
    public Transform flySpawner;    // Ponto de Spawn 1
    public Transform groundSpawner;    // Ponto de Spawn 2
    public Transform woodSpawner;    // Ponto de Spawn 3


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
            float c = Random.Range(1f, 4f); // Gera um número aleatório de 1 e 6

            if (c >= 1 && c <= 2) // Se criar um valor entre 1 e 2
            {
                 Instantiate(flyBody, flySpawner.position, flySpawner.rotation); // Spawna Prefab 1
            }
            else if (c >= 3 && c <= 4) // Se criar um valor maior que 2 e menor que 3
            {
                Instantiate(groundBody, groundSpawner.position, groundSpawner.rotation); // Spawna Prefab 2
            }
            else
            {
                Instantiate(woodBody, woodSpawner.position, woodSpawner.rotation); //Spawna Prefab 3
            }

        }
    }
    
}
