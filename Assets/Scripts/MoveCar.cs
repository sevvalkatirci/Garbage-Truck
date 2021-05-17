using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private float forwardSpeed = 3;
    private void FixedUpdate()
    {
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                transform.position += transform.forward * forwardSpeed * Time.deltaTime;
                /*if (gameObject.transform.position.z >= 106)
                {
                    Destroy(gameObject);
                }*/
                break;
            case GameManager.GameState.FinishGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
