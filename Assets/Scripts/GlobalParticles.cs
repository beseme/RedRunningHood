using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParticles : MonoBehaviour
{
   [SerializeField] private float _offset = 0; 
   public Transform PlayerPos = null;

   private void Update()
   {      
      gameObject.transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y - _offset, gameObject.transform.position.z);
   }
}
