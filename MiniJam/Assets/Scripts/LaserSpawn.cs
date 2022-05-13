using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    public GameObject laser;
    public GameObject rotate;
    public float delay = 0.5f;
    public float lastShot;
    public Collision collision;
    void Update()
    {
        if (Time.time - lastShot > delay)
        {
            if (Input.GetMouseButton(0) && collision.CanMove())
            {
                lastShot = Time.time;
                GameObject temp = Instantiate(laser, transform.position, Quaternion.identity);
                temp.transform.rotation = rotate.transform.rotation;
                temp.transform.rotation *= Quaternion.Euler(0, 0, -90);
                temp.transform.parent = null;
            }
        }
    }
}
