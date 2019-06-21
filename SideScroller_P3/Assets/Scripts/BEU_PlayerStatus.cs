using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BEU_PlayerStatus : MonoBehaviour
{
    float AttackPoint = 10;
    float Health = 100;
    bool isDeath = false;

    public Image HP_image;

    Animator anim;
    BE_GameManager game_manager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        game_manager = GameObject.Find("GameManager").GetComponent<BE_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 0)
        {
            Health = 0;
            isDeath = true;
        }

        if (isDeath)
        {
            game_manager.defeat();
        }
    }

    public void SetDamage(float _damage)
    {
        Health -= _damage;
        HP_image.fillAmount = Health / 100;
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
            //Debug.Log("Me pegan ayuda!");
            //anim.SetTrigger("Stunning_Trigger");
            SetDamage(10f);
        }
    }
}
