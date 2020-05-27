using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private AudioSource death;
    public AudioClip deathSound;

    private Rigidbody2D rb;
    public const int maxHealth = 100;

    public int currentHealth = maxHealth;

    private void Awake()
    {
        death = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int Amount){
        currentHealth -= Amount;
        if(currentHealth<=0){
            currentHealth = 0;
            Debug.Log("DEAD!");
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 2f);
            if(gameObject.tag != "Player")
                Destroy(gameObject);
            else{
                rb.freezeRotation = false;
                rb.AddForce(new Vector2(-6666f, 555f));

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy"){
            TakeDamage(100);
        }
    }
}
