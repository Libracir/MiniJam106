using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy
{
    public float triggerLength = 4;
    public float chaseLength = 10;
    public float speed = 2;
    private bool chasing;
    private Transform playerTransform;
    private Vector3 startingPosition;
    public GameObject player;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Me")
        {
            GameManager.instance.health -= 1;
            Die();
            GameManager.instance.ScreenShake(0.15f, 0.25f);
        } else if (collision.gameObject.tag == "Laser")
        {
            Die();
        }
    }
    void Start()
    {
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 15f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
            {
                if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                {
                    chasing = true;
                }

                if (chasing)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized, speed);
                }
                else
                {
                    UpdateMotor(startingPosition - transform.position, speed);
                    chasing = false;
                }
            }
            startingPosition = transform.position;
            BeeRotate();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void BeeRotate()
    {
        if (playerTransform.position.x - transform.position.x <= 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } 
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
