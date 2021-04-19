using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{   
    // If a collider enters the killzone, if the collider is tagged as a player, call the method to reset the players position
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.BroadcastMessage("respawn");
       }
    }
}
