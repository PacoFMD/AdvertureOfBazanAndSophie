using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_EnemyStatus : MonoBehaviour
{
    [SerializeField]
    float AttackPoint = 10;
    [SerializeField]
    float Health = 100;

    private bool isDead = false;

    Animator anim;

    BE_GameManager Gamemng;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Gamemng = GameObject.Find("GameManager").GetComponent<BE_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 0 && !isDead)
        {
            isDead = true;
            Health = 0;
            anim.SetTrigger("Stunning_Trigger");
            Gamemng.EnemyCount();
            Destroy(this.gameObject, 0.50f);
        }

    }

    public void SetDamage(float _damage)
    {
        Health -= _damage;
    }

    public float GetHealth()
    {
        return Health;
    }

    public float GetAttackPoint()
    {
        return AttackPoint;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "HitPoint")
        {
            SetDamage(collision.transform.parent.GetComponent<BEU_PlayerStatus>().GetAttackPoint());
            //Debug.Log("Me pegan ayuda!");
            SetDamage(25);
            anim.SetTrigger("Stunning_Trigger");
            
            GetComponent<BEU_EnemyMovement>().targetAssign = false;
        }
    }
}
