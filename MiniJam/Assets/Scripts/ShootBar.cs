using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBar : MonoBehaviour
{
    Image image;
    public LaserSpawn laserSpawn;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.fillAmount = (Time.time - laserSpawn.lastShot) * 2;
    }
}
