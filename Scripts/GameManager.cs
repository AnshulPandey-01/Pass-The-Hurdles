using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour{
    public bool check = false;
    public float slow = 3f;
    public GameObject restartLevelUI;
    public AudioSource gameSound;
    public Material Player, Ground, Obstacle;
    public Text score, restartBtn, menuBtn, pauseBtn, highScore;
    
    void Start(){
        gameSound.enabled = PlayerPrefs.GetInt("Music", 1) == 1 ? true : false;
        Theme();
    }

    void Theme(){
        int randomIndex = Random.Range(0, 5);
        if(randomIndex == 0){
            Player.color = new Color(255/255f, 125/255f, 0/255f);
            Ground.color = new Color(53/255f, 26/255f, 7/255f);
            Obstacle.color = new Color(0/255f, 120/255f, 81/255f);
            score.color = Player.color;
            restartBtn.color = Player.color;
            highScore.color = Player.color;
            menuBtn.color = Obstacle.color;
            pauseBtn.color = Obstacle.color;
        }else if(randomIndex == 1){
            Player.color = new Color(0/255f, 0/255f, 0/255f);
            Ground.color = new Color(231/255f, 16/255f, 14/255f);
            Obstacle.color = new Color(51/255f, 0/255f, 125/255f);
            score.color = Player.color;
            restartBtn.color = Player.color;
            highScore.color = Player.color;
            menuBtn.color = Obstacle.color;
            pauseBtn.color = Obstacle.color;
        }else if(randomIndex == 2){
            Player.color = new Color(255/255f, 0/255f, 138/255f);
            Ground.color = new Color(105/255f, 221/255f, 99/255f);
            Obstacle.color = new Color(0/255f, 58/255f, 255/255f);
            score.color = Player.color;
            restartBtn.color = Player.color;
            highScore.color = Player.color;
            menuBtn.color = Obstacle.color;
            pauseBtn.color = Obstacle.color;
        }else if(randomIndex == 3){
            Player.color = new Color(0/255f, 255/255f, 255/255f);
            Ground.color = new Color(119/255f, 18/255f, 253/255f);
            Obstacle.color = new Color(0/255f, 0/255f, 0/255f);
            score.color = Player.color;
            restartBtn.color = Player.color;
            highScore.color = Player.color;
            menuBtn.color = Obstacle.color;
            pauseBtn.color = Obstacle.color;
        }else if(randomIndex == 4){
            Player.color = new Color(0/255f, 255/255f, 0/255f);
            Ground.color = new Color(255/255f, 255/255f, 255/255f);
            Obstacle.color = new Color(255/255f, 0/255f, 0/255f);
            score.color = Player.color;
            restartBtn.color = Player.color;
            highScore.color = Player.color;
            menuBtn.color = Obstacle.color;
            pauseBtn.color = Obstacle.color;
        }
    }
    
    public void Restart(){
        restartLevelUI.SetActive(true);
        FindObjectOfType<AdManager>().ShowVideoAd();
        FindObjectOfType<Ads>().rewardBtnCheck();
    }

    public void EndGame(){
        check = true;
        StartCoroutine(Slowness());
        Invoke("Restart", 0.4f);
    }

    public void GameOverEndGame(){
        check = true;
        Invoke("Restart", 0.2f);
    }

    IEnumerator Slowness(){
        Time.timeScale = 1f / slow;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slow;
        yield return new WaitForSeconds(1f / slow);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slow;
    }
}