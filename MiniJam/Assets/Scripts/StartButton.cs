using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startButton;
    public Sprite sprite;
    private void Start()
    {
        startButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        GetComponent<Image>().sprite = sprite;
        SceneManager.LoadScene("Start");
    }

}
