using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class ExplosionForce : MonoBehaviour
{
    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;
    //[SerializeField] private GameObject objectt;
    private MovePlayer player;
    private bool isTriggered = true;
    

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<MovePlayer>();
        if (player)
        {
            if (isTriggered)
            {
                if (Animations.pickableObjects.Count >= 1)
                {
                    int firstnumber= UnityEngine.Random.Range(0, Animations.pickableObjects.Count-1);
                    Collider collider = Animations.pickableObjects[firstnumber]
                            .GetComponent<Collider>();
                        Rigidbody body= Animations.pickableObjects[firstnumber].GetComponent<Rigidbody>();
                        body.isKinematic = false;
                        collider.enabled = true;
                        body.gameObject.transform.parent = null;
                        body.AddExplosionForce(explosionForce,transform.position,radius);
                        isTriggered = false;
                        Animations.pickableObjects.RemoveAt(firstnumber);
                        Destroy(Animations.collectedObjects[firstnumber]); 
                        Animations.collectedObjects.RemoveAt(firstnumber);
                        
                }
            }
        }
    }
}
