using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 600f;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }   
        else
        {
            time = 0;
            GameManager.instance.health = 0;
        }
        float mins = Mathf.FloorToInt(time / 60);
        float secs = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
}
