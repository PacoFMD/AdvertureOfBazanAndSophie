using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_EnemyMovement : MonoBehaviour
{
    GameObject[] Players;
    GameObject actualTarget;
    public GameObject hitPoint;
    Transform Player;
    RaycastHit2D hit;
    bool canIFollow, canIAttack;
    public bool targetAssign;
    float distance = 0.5f;
    float attackTime = 0f, attackReady = 2f, speedX = 3f, speedY = 0.8f;
    Rigidbody2D myRb;

    float xMov;
    float yMov;
    public Animator anim;
    private float hitPointDisplacement = 0.365f;


    private void Awake()
    {
        myRb = this.GetComponent<Rigidbody2D>();
        Players = GameObject.FindGameObjectsWithTag("Player");
        anim = GetComponent<Animator>();
        hitPointDisplacement = hitPoint.transform.localPosition.x;
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
        //Debug.Log(Players.Length);
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
        if (transform.position.y >= _actualTarget.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        if (canIFollow)
        {
            if(Vector2.Distance(transform.position, _actualTarget.transform.position)> distance)
            {
                anim.SetFloat("Walk_Float", 1);

                if (_actualTarget.transform.position.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    hitPoint.transform.position = new Vector3(transform.position.x + hitPointDisplacement, hitPoint.transform.position.y, transform.position.z);
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    hitPoint.transform.position = new Vector3(transform.position.x - hitPointDisplacement, hitPoint.transform.position.y, transform.position.z);
                }

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_actualTarget.transform.position.x, transform.position.y), speedX * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, _actualTarget.transform.position.y), speedY * Time.deltaTime);


            }
            else if (Vector2.Distance(transform.position, _actualTarget.transform.position) <= distance)
            {
                myRb.velocity = Vector2.zero;
                anim.SetFloat("Walk_Float", 0);
                anim.SetTrigger("Attack_Trigger");
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


        }
    }
}
