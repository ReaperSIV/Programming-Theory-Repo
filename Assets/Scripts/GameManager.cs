using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0; // очки
    public int ballsLeft = 3; // количество шариков
    public float gameTime = 60f; // время игры 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballsLeftText;
    public TextMeshProUGUI gameTimeText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScoreText;

    private bool isGameRunning = true;
    private float remainingTime;


    public GameObject targetPrefab;
    public float spawnDelay = 1f;

    //private float spawnTimer = 0f;

  

    public int targetsOnScene = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = gameTime;
        StartCoroutine(SpawnTargets());
   
        
       

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {

            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                EndGame();
            }

            gameTimeText.text = "Time: " + Mathf.FloorToInt(remainingTime).ToString();
        }
        // Получаем все объекты с тэгом "Target"
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        // Если количество целей на сцене изменилось
        if (targetsOnScene != targets.Length)
        {
            // Обновляем количество целей на сцене
            targetsOnScene = targets.Length;

            
            if (isGameRunning)
            {
                CreateTarget();


                
            }
        
        }

        //spawnTimer -= Time.deltaTime;
        //проверка кол целей на сцене
       
        
        
        
    }


    public void CreateTarget()
    {
        if (targetsOnScene == 0 && ballsLeft > 0)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
            if (targets.Length == 0)
            {
                // Создать новую башню из префаба
                GameObject targetTower = Instantiate(targetPrefab);

                // Расположить башню в случайном месте на игровом поле
                float x = Random.Range(2.38f, 12.41f);
                float y = 1.95f;
                float z = 9.8f;
                targetTower.transform.position = new Vector3(x, y, z);

                targetsOnScene += targetTower.transform.childCount;
                targetsOnScene++;
                // Увеличить количество целей на сцене на количество целей в башне
                // targetsOnScene += targetTower.transform.childCount;
            }
        }


        
    }
    IEnumerator SpawnTargets()
    {
        while (true)
        {
            if (targetsOnScene == 0 && ballsLeft > 0)
            {
                CreateTarget();
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }



    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void DecreaseBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = "Balls: " + ballsLeft.ToString();
        if (ballsLeft <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        isGameRunning = false;
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
