using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{
    public Text highScore;
    private int highScoreValue;

    void Start(){
        highScoreValue = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = "High Score: " + highScoreValue.ToString();
    }

    void Update(){
        int currentScore = Mathf.RoundToInt(FindObjectOfType<Score>().scoreDisplay);
        if(currentScore > highScoreValue){
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore.text = "High Score: " + currentScore.ToString();
        }
    }
}
