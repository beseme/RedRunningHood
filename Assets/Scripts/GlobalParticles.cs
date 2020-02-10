using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParticles : MonoBehaviour
{
   public Transform PlayerPos = null;

   private void Update()
   {      
      gameObject.transform.position = new Vector3(PlayerPos.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
   }
}
