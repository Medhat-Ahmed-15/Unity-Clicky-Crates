using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private int score;
    private float spawnRate = 1;

    public bool isGameActive;


    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator spawnTarget()
    {
       
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

     public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;
        StartCoroutine(spawnTarget());
        // InvokeRepeating("invoke", 1, 1);  dee nafa3t badl IEnumerator
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

    }

    /*void invoke()
    {
      
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        
    }*///dee nafa3t badl el IEnumerator,,bs hya el fekra msh 3arf 2aw2fha emta lama el game yab2 over
}
