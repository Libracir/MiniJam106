using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBar : MonoBehaviour
{
    Image image;
    public Sprite sprite;
    public Sprite normal;
    public LaserSpawn laserSpawn;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if ((Time.time - laserSpawn.lastShot) * 2 >= 1)
        {
            image.sprite = sprite;
        } else
        {
            image.sprite = normal;
        }

        image.fillAmount = (Time.time - laserSpawn.lastShot) * 2;
    }
}
