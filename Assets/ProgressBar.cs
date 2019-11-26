using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    public List<Image> segments;

    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = gameManager.getEnemyCount();
      
        for (int i = 0; i < 4 - enemyCount; i++) {
            if (enemyCount > 4) break;
            segments[i].canvasRenderer.SetColor(Color.blue);
        }
    }
}
