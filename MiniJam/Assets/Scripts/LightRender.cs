using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRender : MonoBehaviour
{
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 25f)
        {
        }
    }
}
