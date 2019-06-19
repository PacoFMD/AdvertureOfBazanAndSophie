using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_EnemyStatus : MonoBehaviour
{
    [SerializeField]
    float AttackPoint = 10;
    [SerializeField]
    float Health = 100;

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
            Debug.Log("Me pegan ayuda!");
            GetComponent<BEU_EnemyMovement>().targetAssign = false;
        }
    }
}
