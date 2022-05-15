using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.End();
    }
}

