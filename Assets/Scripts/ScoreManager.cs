using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour{

    public Text scoreText;
    public Text bestScoreText;

    public static int score = 0;

    void Start(){
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    void Update(){
        if(LifeControl.isOver){
            GetComponent<SpriteRenderer>().enabled = true;

            if(int.Parse(scoreText.text) > int.Parse(bestScoreText.text)){
                bestScoreText.text = scoreText.text;
            }

            PlayerPrefs.SetInt("BestScore", int.Parse(bestScoreText.text));
        }

        if(GetComponent<SpriteRenderer>().enabled && Input.GetMouseButtonDown(0)){
            GetComponent<SpriteRenderer>().enabled = false;
            LifeControl.isOver = false;
            LifeControl.lifeCountLost = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
