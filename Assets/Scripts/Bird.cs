using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;
    public int player_number;
    
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (isDead == false) {
            if (Input.GetMouseButtonDown(0) && player_number == 1) {
                Flap();
            }

            if (Input.GetKeyDown(KeyCode.Space) && player_number == 2) {
                Flap();
            }
        }
    }

    void Flap() {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        anim.SetTrigger("Flap");
    }

    void OnCollisionEnter2D() {
        if (!isDead) {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Die");
            GameControl.instance.BirdDied();
        }
    }
}