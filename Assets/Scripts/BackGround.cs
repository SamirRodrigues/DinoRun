using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour{

    // Esse código faz com que a paisagem no fundo fique se movimentando (PARALLAX)

    public float vel = 1;

    public Renderer cloud1;
    private float velCloud1 = 0.01f;

    public Renderer cloud2;
    private float velCloud2 = 0.02f;

    public Renderer mountain;
    private float velMountain = 0.03f;

    public Renderer vegetation;
    private float velVegetation = 0.3f;

    public Renderer trail;
    private float velTrail = 0.5f;

    public Renderer closedVegetation;
    private float velClosedVegetation = 1f;





    void Update()
    {
        //Cloud1(cloud1);
        //Cloud2(cloud2);
        //Mountain(mountain);
        //Vegetation(vegetation);
        //Trail(trail);
        //ClosedVegetation(closedVegetation);
    }

    void Cloud1(Renderer cloud1)
    {
        Vector2 offset = new Vector2(velCloud1 * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        cloud1.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }

    void Cloud2(Renderer cloud2)
    {
        Vector2 offset = new Vector2(velCloud2 * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        cloud2.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }

    void Mountain(Renderer mountain)
    {
        Vector2 offset = new Vector2(velMountain * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        mountain.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }

    void Vegetation(Renderer vegetation)
    {
        Vector2 offset = new Vector2(velVegetation * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        vegetation.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }

    void Trail(Renderer trail)
    {
        Vector2 offset = new Vector2(velTrail * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        trail.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }

    void ClosedVegetation(Renderer closedVegetation)
    {
        Vector2 offset = new Vector2(velClosedVegetation * Time.deltaTime * vel, 0); //Variável responsável por mover a imagem no eixo X (No caso a variavel recebe (x,y), onde o y = 0.)
        //Time.deltaTime tenta igualar o tempo de rotação da imagem (nesse caso) para que seja o mais próximo possível independente do desempenho da máquina que esteja rodando.

        closedVegetation.material.mainTextureOffset += offset; //Responsável por criar a movimentação no quad, no caso, vai criar o reset da imagem
        //Depois que a imagem chegar no final, vai fazer com que ela seja recarregada no quad (material onde ela foi colocada em cima)
    }


}
