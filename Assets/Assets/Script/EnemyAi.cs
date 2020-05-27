using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    private enemyMovement enemymove;

  
    private GameObject Player;
    [SerializeField]
    int MoveSpeed = 4;
    private int MaxDist = 10;

    private int MinDist = 5;

    private bool isfacingright = true;


    void Start(){
        Player = GameObject.FindWithTag("Player");
        enemymove = GetComponent<enemyMovement>();
    }

    void FixedUpdate(){
        
         if (transform.position.x >= Player.transform.position.x){
            if (isfacingright)
            {
                transform.Rotate(Vector3.up * 180);
                isfacingright = false;
            }

        }
        else{
            if(!isfacingright){
                transform.Rotate(Vector3.up * 180);
                isfacingright = true;
            }
        }
        

        if (Mathf.Abs(Vector3.Distance(transform.position, Player.transform.position)) <= MinDist)
        {
            MinDist = 10000;
            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            enemymove.enabled = false;
            if(!isfacingright)
                transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);


            /*if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }*/

        }
    }

}
