using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour{

    //Esse código faz com que a paisagem no fundo fique se movimentando

    public float vel = 0.1f;
    public Renderer quad;


    void Update() {

        Vector2 offset = new Vector2(vel * Time.deltaTime, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        quad.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }
}
