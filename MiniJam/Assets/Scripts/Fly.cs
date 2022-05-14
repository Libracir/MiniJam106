using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    public float power;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Me" || collision.gameObject.tag == "Laser")
        {
            Die();
        }
    }

    private void LateUpdate()
    {

        float x = Random.Range(-1f, 1f) * power;
        float y = Random.Range(-1f, 1f) * power;

        transform.position += new Vector3(x, y, 0);
    }
}
