using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] public LayerMask groundLayer;
    BoxCollider2D box;
    Rigidbody2D rb;
    float test = 0.1f;
    public float delay = 0.1f;
    public float destroyDelay = 0.4f;
    public GameObject laser;

    public bool next = true;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (next)
        {
            StartCoroutine(Shoot());
        }
        StartCoroutine(Destroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            next = false;
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delay);
        GameObject temp = Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        temp.transform.Translate(transform.up*1.5f, Space.Self);
        temp.transform.parent = null;
        temp.transform.rotation = transform.rotation;
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }
}
