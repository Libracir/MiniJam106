using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Me")
        {
            GameManager.instance.health += 1;
            if (GameManager.instance.health > 4)
            {
                GameManager.instance.health = 4;
            }
            Destroy(this.gameObject);
        }
    }
}
