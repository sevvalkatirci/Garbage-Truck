using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer Instance;
    public float forwardSpeed;
    [SerializeField] private float maxLimit;
    [SerializeField] private float minLimit;
    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                Running();
                break;
            case GameManager.GameState.FinishGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Running()
    {
        transform.Translate(transform.forward * (forwardSpeed/3.6f * Time.deltaTime),Space.World);
    }

    public void Turn(float movementVale)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementVale, minLimit, maxLimit),
            transform.position.y, transform.position.z);
    }
}
