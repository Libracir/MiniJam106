using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject blam;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;

    protected RaycastHit2D hit;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GameObject temp = Instantiate(blam, transform.position, Quaternion.identity);
        temp.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        temp.transform.parent = null;
        GameManager.instance.scorePoints += 1;
        Destroy(this.gameObject);
    }
    protected virtual void UpdateMotor(Vector3 input, float speed)
    {
        moveDelta = input * speed;
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
