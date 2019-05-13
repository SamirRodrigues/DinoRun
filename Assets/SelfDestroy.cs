using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public GameObject Player;

    public void PlayerDestroy()
    {
        Destroy(Player);
    }
}
