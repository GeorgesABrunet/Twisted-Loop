using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleTurn : MonoBehaviour
{
    public static float TurnSpeed;
    void Start()
    {
        TurnSpeed = -0.35f;
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused != true)
        {
            if (TurnSpeed >= 0.4)
            {
                TurnSpeed += 0.0008f;
            }
            else if (TurnSpeed < -0.4)
            {
                TurnSpeed -= 0.0008f;
            }
            else
            {
                TurnSpeed += 0.008f;
            }
            transform.Rotate( 0, TurnSpeed, 0, Space.World);
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.World);
        }
    }
}
