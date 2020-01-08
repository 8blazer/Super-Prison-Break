using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    public bool activated;
    bool Grown;
    bool Shrunk;

    public Transform player;
    public GameObject GOplayer;

    public float hp;
    float totalHp;

    //Top Platform
    public Transform Tpoint1;
    public Transform Tpoint2;
    bool collidedT;

    //Left Plaform
    public Transform LJumpPoint;
    public Transform Lpoint1;
    public Transform Lpoint2;
    bool collidedL;

    //Right Platform
    public Transform RjumpPoint;
    public Transform Rpoint1;
    public Transform Rpoint2;
    bool collidedR;

    float origianlMoveSpeed;
    public float moveSpeed;

    public float phaseSwitchCheck;
    float phaseTimer;
    int phase;

    float paceTimer;

    // Start is called before the first frame update
    void Start()
    {
        collidedL = false;
        collidedR = false;
        collidedT = false;
        Grown = false;
        Shrunk = false;
        totalHp = hp;
        origianlMoveSpeed = moveSpeed;
        phase = Random.Range(1, 4);

    }

    // Update is called once per frame
    void Update()
    {
        paceTimer += Time.deltaTime;
        phaseTimer += Time.deltaTime;
        //Grow and Shrink Activation
        if (hp < 75 % (totalHp))
        {
            Shrink();
        }
        if (hp < 50 % (totalHp))
        {
            Grow();
        }
        if (hp < 1 % (totalHp))
        {
            Die();
        }
        //Phase Activation
        switch (phase)
        {
            case 1:
                Phase1();
                break;
            case 2:
                Phase2();
                break;
            case 3:
                Phase3();
                break;

        }
        //Phase Switch P1 = Pace P2 = Chase P3 = Run
        if (phaseTimer > phaseSwitchCheck)
        {
            switch (phase)
            {
                case 1:
                    phase = Random.Range(2, 4);
                    break;
                case 2:
                    int random = Random.Range(1, 3);
                    switch (random)
                    {
                        case 1:
                            phase = 1;
                            break;
                        case 2:
                            phase = 3;
                            break;
                    }
                    break;
                case 3:
                    phase = Random.Range(1, 3);
                    break;

            }
            phaseTimer = 0;
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                collidedT = true;
                break;
            case "Boss1LP":
                collidedL = true;
                break;
            case "Boss1RP":
                collidedR = true;
                break;

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                collidedT = false;
                break;
            case "Boss1LP":
                collidedL = false;
                break;
            case "Boss1RP":
                collidedR = false;
                break;
        }
    }
    void Phase1()
    {
        //Pace on Current Platform
        if (collidedT)
        {
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
            if (phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Tpoint1.position.x) < .05 ||
                phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Tpoint2.position.x) < .05)
            {
                moveSpeed *= -1;
                phaseTimer = 0;
            }
        }
        if (collidedR)
        {
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
            if (phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Rpoint1.position.x) < .05 ||
                phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Rpoint2.position.x) < .05)
            {
                moveSpeed *= -1;
                phaseTimer = 0;
            }
        }
        if (collidedL)
        {
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
            if (phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Lpoint1.position.x) < .05 ||
                phaseTimer > 0.1f && Mathf.Abs(transform.position.x - Lpoint2.position.x) < .05)
            {
                moveSpeed *= -1;
                phaseTimer = 0;
            }
        }
    }
    void Phase2()
    {
        if (collidedT)
        {

        }
    }
    void Phase3()
    {

    }
    void Grow()
    {
        Shrunk = false;
        Grown = true;
        moveSpeed = 50 % (origianlMoveSpeed);
    }
    void Shrink()
    {
        Shrunk = true;
        moveSpeed = 150 % (origianlMoveSpeed);
    }
    void Die()
    {

    }
}
