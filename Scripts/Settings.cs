using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour{

    public AudioSource musicSource, buttonSource;
    public Text musicBtnTxt, soundBtnTxt;
    private int musicState, soundState;

    void Start() {
        musicState = PlayerPrefs.GetInt("Music", 1);
        soundState = PlayerPrefs.GetInt("Sound", 1);

        MusicSound();
        SetText();
    }

    private void MusicSound(){
        musicSource.enabled = musicState == 1 ? true : false;
    }

    public void ButtonSound(){
        if(soundState==1) buttonSource.Play();
    }

    private void SetText(){
        if(musicState==1) musicBtnTxt.text = "Music On";
        else musicBtnTxt.text = "Music Off";

        if(soundState==1) soundBtnTxt.text = "Sound On";
        else soundBtnTxt.text = "Sound Off";
    }
    
    public void MusicBtn(){
        musicState = PlayerPrefs.GetInt("Music", 1);
        musicState = musicState == 1 ? 0 : 1;
        PlayerPrefs.SetInt("Music", musicState);

        ButtonSound();
        SetText();
        MusicSound();
    }

    public void SoundBtn(){
        soundState = PlayerPrefs.GetInt("Sound", 1);
        soundState = soundState == 0 ? 1 : 0;
        PlayerPrefs.SetInt("Sound", soundState);

        ButtonSound();
        SetText();
    }

    public void Back(){
        ButtonSound();
        SceneManager.LoadScene("Menu");
    }
}
