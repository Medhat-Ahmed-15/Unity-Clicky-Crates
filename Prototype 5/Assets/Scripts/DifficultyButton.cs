using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficultyRate;
   
    void Start()
    {
     
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
       
        button.onClick.AddListener(setDifficulty);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
        Debug.Log("done");
     
        gameManager.StartGame(difficultyRate);
    }
}
