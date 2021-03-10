using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour{
    public bool isPause = false;
    public GameObject pauseMenuUI, pauseCanvas;
    public Text pauseBtn;

    void Update(){
        if(FindObjectOfType<GameManager>().check == true){
            pauseCanvas.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPause){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        FindObjectOfType<AudioManager>().ButtonSound();
        pauseMenuUI.SetActive(false);
        pauseBtn.text = "PAUSE";
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Pause(){
        FindObjectOfType<AudioManager>().ButtonSound();
        pauseMenuUI.SetActive(true);
        pauseBtn.text = "";
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Restart(){
        FindObjectOfType<AudioManager>().ButtonSound();
        StartCoroutine(waitRestart());
    }
    
    public void Menu(){
        FindObjectOfType<AudioManager>().ButtonSound();
        StartCoroutine(waitMenu());
    }

    IEnumerator waitRestart(){
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator waitMenu(){
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
