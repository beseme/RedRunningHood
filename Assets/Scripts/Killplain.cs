﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<EnterSection>();
        player.ResetPosition();
    }
}
