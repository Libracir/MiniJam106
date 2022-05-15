using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startButton;
    private void Start()
    {
        startButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Start");
    }

}
