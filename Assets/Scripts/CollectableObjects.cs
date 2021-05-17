using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
   private MovePlayer player;
   private FinishCollider _finishCollider;

   private void Start()
   {
      _finishCollider = FindObjectOfType<FinishCollider>();
   }

   /*private void Update()
   {
      if (!_finishCollider.isTrigger)
      {
         gameObject.GetComponent<Rigidbody>().isKinematic = false;
         gameObject.transform.parent = null;
      }
   }*/
}
