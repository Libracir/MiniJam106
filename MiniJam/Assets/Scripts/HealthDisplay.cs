using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Sprite full;
    public Sprite empty;
    public int health;

    private void Update()
    {            
        if (GameManager.instance.health >= health)
        {
            GetComponent<Image>().sprite = full;
        } else
        {
            GetComponent<Image>().sprite = empty;
        }
    }
}
