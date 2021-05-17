using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float smoothness;
    private float startX;
    private float lastX;
    private float distance;
    private float moveValue;

    private void Update()
    {
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                if (Input.GetMouseButtonDown(0))
                {
                    startX = Input.mousePosition.x;
                }
                else if (Input.GetMouseButton(0))
                {
                    lastX = Input.mousePosition.x;
                    distance = lastX - startX;
                    moveValue = (distance / Screen.width) * smoothness;
                    MovePlayer.Instance.Turn(moveValue);
                    startX = lastX;
                }
                break;
            case GameManager.GameState.FinishGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
