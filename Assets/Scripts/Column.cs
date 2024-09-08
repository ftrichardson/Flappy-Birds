using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Bird bird = other.GetComponent<Bird>();
        
        if (bird != null) {
            GameControl.instance.BirdScored(bird.player_number);
        }
    }
}
