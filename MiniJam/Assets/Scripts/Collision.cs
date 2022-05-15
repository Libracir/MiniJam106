using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    BoxCollider2D box;
    [SerializeField] public LayerMask groundLayer;
    float test = 0.1f;

    public bool down;
    public bool right;
    public bool left;
    public bool up;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        down = IsGrounded();
        right = IsRightWall();
        left = IsLeftWall();
        up = IsRoof();
    }

    public bool CanMove()
    {
        if (IsGrounded() || IsRoof() || IsLeftWall() || IsRightWall())
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size + new Vector3(-0.01f, 0, 0), 0, Vector2.down, test, groundLayer);
        return raycast.collider != null;
    }
    public bool IsRoof()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size + new Vector3(-0.01f, 0, 0), 0, Vector2.up, test, groundLayer);
        return raycast.collider != null;
    }
    public bool IsLeftWall()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size + new Vector3(0, -0.01f, 0), 0, Vector2.left, test, groundLayer);
        return raycast.collider != null;
    }
    public bool IsRightWall()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size + new Vector3(0, -0.01f, 0), 0, Vector2.right, test, groundLayer);
        return raycast.collider != null;
    }
}
