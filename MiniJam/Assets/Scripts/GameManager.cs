using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int health = 3;
    public Player player;
    public ScreenShake shake;
    public Text score;
    public int scorePoints;
    public GameObject damage;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenShake(1, 10);
        }

        if (health <= 0)
        {
            player.Die();
        }

        score.text = scorePoints.ToString();
    }

    public void ScreenShake(float length, float power)
    {
        GetComponent<AudioSource>().Play();
        shake.StartShake(length, power);
        damage.SetActive(true);
        StartCoroutine(Bonked(length));
    }

    IEnumerator Bonked(float length)
    {
        yield return new WaitForSeconds(length);
        damage.SetActive(false);
    }
}
