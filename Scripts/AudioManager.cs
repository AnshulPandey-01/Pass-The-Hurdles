using UnityEngine;

public class AudioManager : MonoBehaviour{
    public AudioSource obstacleSound, multiplyerSound, coinSound, buttonSound;
    int soundState;

    void Start() {
        soundState = PlayerPrefs.GetInt("Sound", 1);
    }

    public void obstacle(){
        if(soundState==1) obstacleSound.Play();
    }

    public void multiplyer(){
        if(soundState==1) multiplyerSound.Play();
    }

    public void coin(){
        if(soundState==1) coinSound.Play();
    }

    public void ButtonSound(){
        if(soundState==1) buttonSound.Play();
    }
}
