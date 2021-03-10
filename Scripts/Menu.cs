using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    public Text coins, HighScore;
    private string[] charArray = {"Sphere", "Car", "Police Car", "f1Car"};
    private int[] costArray = {50, 500, 1000, 2000};
    
    void Start(){
        int NoOfCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        coins.text = NoOfCoins.ToString();

        int highScoreValue = PlayerPrefs.GetInt("HighScore", 0);
        HighScore.text = "High Score: " + highScoreValue.ToString();
    }

    public void StartGame(){
        int ch_no = FindObjectOfType<PlayerSelecter>().getCharacterNo();
        FindObjectOfType<PlayerSelecter>().ButtonSound();
        if(ch_no==0){
            SceneManager.LoadScene("GameScene");
            return ;
        }
        int cost = PlayerPrefs.GetInt(charArray[ch_no-1], costArray[ch_no-1]);
        if(cost==0){
            SceneManager.LoadScene("GameScene");
        }
        else{
            FindObjectOfType<PlayerSelecter>().DialogBox("Selected Character is not Unlocked.", "Ok", "Cancel");
        }
    }

    public void Settings(){
        FindObjectOfType<PlayerSelecter>().ButtonSound();
        SceneManager.LoadScene("Settings");
    }

    public void Quit(){
        FindObjectOfType<PlayerSelecter>().ButtonSound();
        Application.Quit();
    }
}
