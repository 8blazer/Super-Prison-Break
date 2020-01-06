using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public AudioSource attack;
    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackS();
        }
    }
    void AttackS()
    {
        anim.SetTrigger("attack");

    }
    void Attack()
    {
        attack.Play();
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hit)
        {
            enemy.GetComponent<EnemyHp>().TakeDamage(50);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}