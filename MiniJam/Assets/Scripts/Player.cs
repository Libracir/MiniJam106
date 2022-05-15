using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3f;
    public bool standing;
    public Collision collision;
    public bool delay;
    private bool delayCheck;
    public float audioVariaty;

    public Sprite left;
    public Sprite right;
    public Sprite normal;
    public Sprite ball;
    public GameObject gun;
    public GameObject blam;
    public GameObject Death;
    public bool lavaDelay;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!delayCheck)
        {
            standing = collision.CanMove();
        }
        if (standing) 
        {
            gun.GetComponent<SpriteRenderer>().enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            if (Input.GetMouseButtonDown(1))
            {

                AudioSource audio = GetComponent<AudioSource>();
                audio.pitch = 0.75f + Random.Range(-1f, 1f) * audioVariaty;
                audio.Play();


                GameObject temp = Instantiate(blam, transform.position, Quaternion.identity);
                temp.transform.position += new Vector3(0, -0.5f, 0);
                temp.transform.parent = null;

                standing = false;
                delayCheck = true;
                StartCoroutine(delay3());
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                delay = true;
                StartCoroutine(delayStick());
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
                StartCoroutine(delay2());

            }
            if (!delay)
            {
                if (collision.IsLeftWall())
                {
                    transform.rotation = new Quaternion(0, 0, 270, 0);
                    GetComponent<SpriteRenderer>().sprite = right;
                }
                else if (collision.IsRightWall())
                {
                    transform.rotation = new Quaternion(0, 0, 90, 0);
                    GetComponent<SpriteRenderer>().sprite = left;
                }
                else if (collision.IsGrounded())
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    GetComponent<SpriteRenderer>().sprite = normal;
                }
                else if (collision.IsRoof())
                {
                    transform.rotation = new Quaternion(0, 0, 180, 0);
                    GetComponent<SpriteRenderer>().sprite = normal;
                }
            }
        } else
        {
            GetComponent<SpriteRenderer>().sprite = ball;
            gun.GetComponent<SpriteRenderer>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            if (!lavaDelay)
            {
                lavaDelay = true;
                StartCoroutine(delayLava());
                GameManager.instance.health -= 1;
                GameManager.instance.ScreenShake(0.15f, 0.25f);
            }
        }
    }


    IEnumerator delay2()
    {
        yield return new WaitForSeconds(0.001f);
        rb.AddRelativeForce(new Vector2(0, 1) * speed, ForceMode2D.Impulse);
    }
    IEnumerator delay3()
    {
        yield return new WaitForSeconds(0.1f);
        delayCheck = false;
        
    }
    IEnumerator delayStick()
    {
        yield return new WaitForSeconds(0.05f);
        delay = false;
    }
    IEnumerator delayLava()
    {
        yield return new WaitForSeconds(0.5f);
        lavaDelay = false;
    }

    public void Die()
    {
        GameObject temp = Instantiate(blam, transform.position, Quaternion.identity);
        temp.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        temp.transform.parent = null;
        Death.SetActive(true);
        Destroy(this.gameObject);
    }
}
