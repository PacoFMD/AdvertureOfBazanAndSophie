using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_EnemyMovement : MonoBehaviour
{
    GameObject[] Players;
    GameObject actualTarget;
    Transform Player;
    RaycastHit2D hit;
    bool canIFollow, canIAttack;
    public bool targetAssign;
    float distance = 1f;
    float attackTime = 0f, attackReady = 2f, speedX = 3f, speedY = 0.8f;
    Rigidbody2D myRb;

    float xMov;
    float yMov;

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
                    if (Vector3.Distance(transform.position, Players[0].transform.position) > Vector3.Distance(transform.position, Players[1].transform.position))
                    {
                        actualTarget = Players[1];
                        targetAssign = true;
                    }
                    else
                    {
                        actualTarget = Players[0];
                        targetAssign = true;
                    }
                }
            }   
        }
        Follow(actualTarget);
    }

    void Follow(GameObject _actualTarget)
    {
        if (canIFollow)
        {
            if(Vector2.Distance(transform.position, _actualTarget.transform.position)> distance)
            {
                //transform.LookAt(Player);
                if (_actualTarget.transform.position.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }

                transform.position = Vector2.MoveTowards(transform.position, new Vector3(_actualTarget.transform.position.x, transform.position.y, 0), speedX * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, _actualTarget.transform.position.y, 0), speedY * Time.deltaTime);

                /*xMov *= speedX * Time.deltaTime;
                xMov += _actualTarget.transform.position.x;
                yMov *= speedY * Time.deltaTime;
                yMov += _actualTarget.transform.position.y;*/

                //transform.Translate(xMov, yMov, 0);

                if (myRb.velocity.sqrMagnitude != 0)
                {
                    //EnemyWalk Animation true
                }

            }else if (Vector2.Distance(transform.position, _actualTarget.transform.position) <= distance)
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
