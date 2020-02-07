using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParticles : MonoBehaviour
{
   public PlayerMovement MoveRef;
   public Transform PlayerPos = null;
   public Transform RollPos = null;

   private void Update()
   {
      if(!MoveRef._rolling)
      gameObject.transform.position = new Vector3(PlayerPos.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
      else
      {
         gameObject.transform.position = new Vector3(RollPos.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
      }
   }
}
