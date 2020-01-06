using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int maxhealth;
    public int currentHealth = 1;
    public AudioSource hurt;
    public Animator anim;
    float timer = 0f;
    bool bossdead;
    bool boss;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        bossdead = false;
        if (gameObject.name == "Boss")
        {
            boss = true;
        }
        else
        {
            boss = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5 && bossdead)
        {

            Application.Quit();
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("oog");
        currentHealth -= damage;
        hurt.pitch = 1;
        float pitch = hurt.pitch;
        float sounddiffer = Random.Range(-.5f, .5f);
        pitch = pitch + sounddiffer;
        hurt.pitch = pitch;
        hurt.Play();

        if (currentHealth <= 0)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            anim.SetTrigger("death");
        }
    }
    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        //PlayerMovement.kills += 1;

        //PlayerMovement.hp += 5;
       // if (boss)
       // {
        //    timer = 0;
       //     bossdead = true;
        //}

    }
    public void BossDie()
    {
        timer = 0;
        bossdead = true;

    }
}
