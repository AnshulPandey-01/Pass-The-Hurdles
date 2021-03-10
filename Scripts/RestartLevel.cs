using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class RestartLevel : MonoBehaviour{
    public Text coinsTextField, totalCoins;
    private int coinsAtStart;

    void Start(){
        coinsAtStart = PlayerPrefs.GetInt("NoOfCoins", 0);
    }

    public void coinsCollect(){
        int currentCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        int coinsCollected = currentCoins - coinsAtStart;
        coinsTextField.text = "COINS COLLECTED\n" + coinsCollected.ToString();
        TotalCoin();
    }

    public void TotalCoin(){
        int currentCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        totalCoins.text = currentCoins.ToString();
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
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator waitMenu(){
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
