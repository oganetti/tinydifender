using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject canvasMenu;

    [SerializeField]
    private GameObject canvasGameOver;

    [SerializeField]
    private GameObject canvasInGame;

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale =  1;
        canvasMenu.SetActive(false);
        canvasInGame.SetActive(true);

    }

    public void GameOver()
    {
        Time.timeScale =  0;
        canvasGameOver.SetActive(true);
        canvasInGame.SetActive(false);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        canvasMenu.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasInGame.SetActive(true);
    }
}
