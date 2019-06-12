using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_PlayerStatus : MonoBehaviour
{
    float AttackPoint = 10;
    float Health = 100;
    bool isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 0)
        {
            Health = 0;
            isDeath = true;
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
        if (collision.transform.tag == "HitPointEnemy")
        {
            //SetDamage(collision.transform.parent.GetComponent<BEU_EnemyStatus>().GetAttackPoint());
            Debug.Log("Me pegan ayuda!");
        }
    }
}
