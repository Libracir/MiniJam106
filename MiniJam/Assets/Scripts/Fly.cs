using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    public float power;
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Me" || collision.gameObject.tag == "Laser")
        {
            Die();
        }
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 15f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            float x = Random.Range(-1f, 1f) * power;
            float y = Random.Range(-1f, 1f) * power;

            transform.position += new Vector3(x, y, 0);
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
