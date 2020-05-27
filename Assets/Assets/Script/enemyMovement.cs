using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    private float MinX;
    public float disCov = 7f;
    private float MaxX;
    int Direction = 1;
    float EnemyX;
    private bool isfacingright = true;
    public float EnemySpeed = 15f;

    private void Awake()
    {
        EnemyX = transform.position.x;
        MinX = transform.position.x;
        MaxX = MinX + disCov;

    }
    void Start () {
        
    }
    
    void FixedUpdate () {
        EnemyX = transform.position.x;

        switch(Direction){
            case -1: if(EnemyX <= MinX)
                    Direction = 1;
                break;
            case 1: if (EnemyX >= MaxX)
                    Direction = -1;
                break;
            default: break;
                
        }
        if(Direction == 1){
            if(!isfacingright){
                transform.Rotate(Vector3.up * 180);
                isfacingright = true;
            }
            transform.Translate(Vector3.right * EnemySpeed * Time.deltaTime);
        }
        else{
            if (isfacingright)
            {
                transform.Rotate(Vector3.up * 180);
                isfacingright = false;
            }
            transform.Translate(Vector3.left * -EnemySpeed * Time.deltaTime);
        }

        
    }
}
