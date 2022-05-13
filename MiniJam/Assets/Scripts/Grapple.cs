using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float speed;
    public Vector3 position;
    private Vector3 start;
    private float distance;
    private float remainingDistance;
    [SerializeField] public LayerMask groundLayer;
    public GameObject tounge;
    public bool cancelGrapple = false;
    public Collision collision;
    public bool locked = true;


    private Vector3 Cast()
    {
        Vector3 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, tempPos - transform.position, 100f, groundLayer);
        return hit.point;
    }


    private void Update()
    {
        if (cancelGrapple)
        {
            MoveToPosition(transform.position);
            tounge.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.CanMove() && !locked)
        {
            cancelGrapple = true;
        }


        if (remainingDistance > 0 && !cancelGrapple)
        {
            transform.position = Vector3.Lerp(start, position, 1 - (remainingDistance / distance));
            tounge.transform.position = transform.position + (position - transform.position) / 2;
            remainingDistance -= speed * Time.deltaTime;
            tounge.transform.localScale = new Vector3(Vector3.Distance(position, transform.position), 1, 1);
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (collision.CanMove())
            {
                tounge.GetComponent<SpriteRenderer>().enabled = true;
                locked = true;
                cancelGrapple = false;
                StartCoroutine(DelayGrapple());
                MoveToPosition(Cast());
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                tounge.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }


    public void MoveToPosition(Vector3 position)
    {
        start = transform.position;
        distance = Vector3.Distance(start, position);
        remainingDistance = distance;
        this.position = position;
    }

    IEnumerator DelayGrapple()
    {
        yield return new WaitForSeconds(0.1f);
        locked = false;
    }
}
