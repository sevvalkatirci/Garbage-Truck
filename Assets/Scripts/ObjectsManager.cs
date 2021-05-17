using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
   

   
    void FixedUpdate()
    {
        if (FinishCollider.isTrigger == true)
        {
            if (Animations.collectedObjects.Count != 0)
            {
                for (int i = 0; i < Animations.collectedObjects.Count; i++)
                {
                    Animations.pickableObjects[i].transform.localPosition =
                        Animations.collectedObjects[i].transform.localPosition;
                    Animations.pickableObjects[i].transform.localRotation =
                        Animations.collectedObjects[i].transform.localRotation;
                }
            }
        }
        
    }
}
