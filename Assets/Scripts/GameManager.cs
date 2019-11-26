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
    public Transform defaultKingPosition;

    [SerializeField]
    public GameObject king;

    bool isKingSpawned=false;

    private int enemyCount = 4;

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 1 && !isKingSpawned) {
            king.SetActive(true);
            //Instantiate(king, defaultKingPosition.position,defaultKingPosition.rotation);
            isKingSpawned = true;
        }
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
