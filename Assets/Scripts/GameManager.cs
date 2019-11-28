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

    [SerializeField]
    private GameObject canvasMarket;

    [SerializeField]
    private GameObject canvasLevelComplete;

    [SerializeField]
    public Transform defaultKingPosition;

    [SerializeField]
    private GameObject king;

    [SerializeField]
    private Animator runAnimation;

    bool isKingSpawned=false;

    //public List<AudioSource> audioSources;
    [SerializeField]
    private GameObject closeButton;

    [SerializeField]
    private GameObject openButton;



    private int enemyCount = 4;

    void Start()
    {
        enemyCount = 4;
        Time.timeScale = 0;

        if(SceneManager.GetActiveScene().buildIndex == 0) 
        {
            PlayerPrefs.SetInt("money", 2000);
            PlayerPrefs.SetInt("green", 0);
            PlayerPrefs.SetInt("blue", 0);
            PlayerPrefs.SetInt("red", 0);
            PlayerPrefs.SetInt("magenta", 0);
            PlayerPrefs.SetString("currentColor", "black");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 1 && !isKingSpawned) {
            king.SetActive(true);
            //Instantiate(king, defaultKingPosition.position,defaultKingPosition.rotation);
            isKingSpawned = true;
        }

        if(enemyCount == 0)
        {
            LevelComplete();
            enemyCount = 4;
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void closeSound()
    {
        /*foreach (AudioSource audioSorce in audioSources)
        {
            audioSorce.Stop();
        }*/

        AudioListener.pause = true;
        openButton.SetActive(false);
        closeButton.SetActive(true);

    }

    public void openSound()
    {
        AudioListener.pause = false;
        closeButton.SetActive(false);
        openButton.SetActive(true);
    }

    public void LevelComplete()
    {
        canvasMenu.SetActive(false);
        canvasInGame.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasLevelComplete.SetActive(true);
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        runAnimation.Play("Run");
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 2000);
        Debug.Log(PlayerPrefs.GetInt("money"));


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

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        canvasMenu.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasInGame.SetActive(false);
        canvasMarket.SetActive(true);

    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        canvasMenu.SetActive(true);
        canvasGameOver.SetActive(false);
        canvasInGame.SetActive(false);
        canvasMarket.SetActive(false);

    }

    public int getEnemyCount() {
        return enemyCount;
    }

    public void onEnemyDie() {
        enemyCount--;
    }
    
}
