using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_EnemyMovement : MonoBehaviour
{
    GameObject[] Players;
    Transform Player;
    RaycastHit2D hit;
    bool canIFollow, canIAttack, targetAssign;
    float distance = 1f;
    float attackTime = 0f, attackReady = 2f, speed = 5f;
    Rigidbody2D myRb;

    private void Awake()
    {
        myRb = this.GetComponent<Rigidbody2D>();
        Players = GameObject.FindGameObjectsWithTag("Player");
        
    }
    // Start is called before the first frame update
    void Start()
    {

        canIFollow = true;
        targetAssign = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Players.Length);
        if (!targetAssign)
        {
            for (int i = 0; i < Players.Length; i++)
            {
               
                if (hit = (Physics2D.Raycast(transform.position, Players[i].transform.position))){
                    Debug.DrawRay(transform.position,  Players[i].transform.position - transform.position, Color.green);
                }
            }   
        }
        //Follow();
    }

    void Follow()
    {
        if (canIFollow)
        {
            if(Vector2.Distance(transform.position, Player.position)> distance)
            {
                transform.LookAt(Player);
                myRb.velocity = transform.forward * speed;
                if (myRb.velocity.sqrMagnitude != 0)
                {
                    //EnemyWalk Animation true
                }

            }else if (Vector2.Distance(transform.position, Player.position) <= distance)
            {
                myRb.velocity = Vector2.zero;
                //Enemy Attack Anim, EnemyWalk false
                //CanIFollow = false;

            }
        }
    }

    void Attack()
    {
        if (canIAttack)
        {
            attackTime += Time.deltaTime;
            if(attackTime > attackReady)
            {
                //AnimationEnemyAttack 
                attackTime = 0;
            }
           /* if (Vector2.Distance(transform.position, Player.position) > )
            {

            }*/
        }
    }
}
