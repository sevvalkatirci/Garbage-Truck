using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    private MovePlayer player;
    private InputManager _inputManager;
    public static bool isTrigger = true;
    [SerializeField] private GameObject leftPlayer;
    [SerializeField] private GameObject rightPlayer;
    
    private void Start()
    {
        _inputManager = FindObjectOfType<InputManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<MovePlayer>();
        if (isTrigger)
        {
            if (player)
            {
                player.transform.position=Vector3.Lerp(player.transform.position,player.transform.position+new Vector3(0,6f,0),4);
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation,Quaternion.Euler(-60,0,0),4);
                _inputManager.enabled = false;
                player.forwardSpeed = 0;
                leftPlayer.SetActive(false);
                rightPlayer.SetActive(false);
                isTrigger = false;
                foreach (var VARIABLE in Animations.pickableObjects)
                {
                    VARIABLE.GetComponent<Rigidbody>().isKinematic = false;
                    VARIABLE.GetComponent<Collider>().enabled = true;
                   // VARIABLE.transform.parent = null;
                }
               
                
            }
            
        }
    }
}
