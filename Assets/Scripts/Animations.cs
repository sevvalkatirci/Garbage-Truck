using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private CollectableObjects objects;
    [SerializeField] Animator _animator;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Transform newTargetPosition;
    [SerializeField] private Transform playerHand;
    public static List<GameObject> pickableObjects = new List<GameObject>();
    public static List<GameObject> collectedObjects = new List<GameObject>();
    public bool isStarted = true;
    private void OnTriggerEnter(Collider other)
    {
        objects=other.GetComponent<CollectableObjects>();
        if (objects)
        {
            if (isStarted)
            {
                isStarted = false;
              
                Debug.Log(pickableObjects.Count);
                _animator.SetTrigger("Collect");
                other.gameObject.transform.parent = playerHand;
                other.gameObject.transform.localPosition=Vector3.zero;
                StartCoroutine(wait(other.gameObject));
            }
        }
    }
    IEnumerator wait(GameObject objects)
    {
        GameObject newObject;
        yield return new WaitForSeconds(0.7f);
        objects.transform.parent = targetPosition;
        objects.transform.position = targetPosition.position;
        collectedObjects.Add(objects);
        newObject= Instantiate(objects, Vector3.zero, Quaternion.identity);
        pickableObjects.Add(newObject);
        newObject.transform.parent=newTargetPosition;
        newObject.transform.position = newTargetPosition.position+objects.transform.localPosition;
        newObject.transform.rotation = objects.transform.localRotation;
        newObject.GetComponent<Collider>().enabled = false;
        newObject.GetComponent<Rigidbody>().isKinematic = true;
        isStarted = true;
 
    }
}
