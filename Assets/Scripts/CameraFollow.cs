using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform target;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                Vector3 targetPosition = target.position + offset;
                targetPosition.x = 0f;
                transform.position = targetPosition;
                break;
            case GameManager.GameState.FinishGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
