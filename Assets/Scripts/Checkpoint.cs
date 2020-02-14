using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<EnterSection>();
        player.SetCheckpoint(collision.gameObject.transform.position);
    }
}
