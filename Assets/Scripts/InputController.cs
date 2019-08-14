using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Attack attack = null;

    void Update()
    {
        // Ground attack
        if (Input.GetKeyDown(KeyCode.Z))
            attack.Kick();

        // Air attack (Head Attack)
        if (Input.GetKeyDown(KeyCode.X))
            attack.HeadAttack();

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            attack.Jump();
    }
}
