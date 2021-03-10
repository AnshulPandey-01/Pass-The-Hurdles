using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float scoreDisplay;
    public Text scoreText;
    private string message = "Final Score: ";
    private int powerMultiplyer = 1, actualMultiplyer = 4, nextIncrese = 125, decider;
    private float timeLimit = 0f, x = 0f;

    public void Start(){
        //Taking decider variable to call the right class according to character.
        decider = PlayerPrefs.GetInt("character_no", 0);
    }
    
    public void Update(){
        if (FindObjectOfType<GameManager>().check == false){
            if(timeLimit < Time.timeSinceLevelLoad && powerMultiplyer!=1){
                powerMultiplyer = 1;
                //for cube and sphere
                if(decider <= 1)
                    FindObjectOfType<DestroyEffect>().multi = 1;
                //for car and police car
                else
                    FindObjectOfType<GameOver>().multi = 1;
            }

            if(Time.timeSinceLevelLoad>nextIncrese && nextIncrese<375){
                actualMultiplyer++;
                nextIncrese += 125;
        }

            float a = Time.timeSinceLevelLoad - x;
            scoreDisplay += a * actualMultiplyer * powerMultiplyer;
            scoreText.text = scoreDisplay.ToString("0");
            x = Time.timeSinceLevelLoad;
        }
        else{
            Invoke("FinalScore", 0.8f);
        }
    }

    public void multiplyer(){
        powerMultiplyer = 2;
        timeLimit = Time.timeSinceLevelLoad + 10;
    }

    void FinalScore(){
        scoreText.text = message + scoreDisplay.ToString("0");
    }
}
