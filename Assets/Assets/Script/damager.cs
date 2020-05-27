using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damager : MonoBehaviour {
    [SerializeField]
    public AudioClip bubbles;

    public float vol = 55f;

    private Renderer rend;

    private int flag = 0;

    public AudioSource bubble;

    Health EnemyHealth;

    private void Awake()
    {
        bubble = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (flag == 1)
           // Destroy(gameObject);
        if (collision.collider.tag == "Player")
            return;
        
        //bubble.PlayOneShot(bubbles);
        //flag = 1;
        //rend.enabled = false;
        if(collision.collider.tag == "Enemy"){
            EnemyHealth = collision.collider.GetComponent<Health>();
            EnemyHealth.TakeDamage(20);
        }
        AudioSource.PlayClipAtPoint(bubbles, transform.position, vol);
        Destroy(gameObject);
        //Debug.Log("Boom!");
    }

   
}

