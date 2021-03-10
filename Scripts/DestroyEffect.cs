using UnityEngine;
using UnityEngine.UI;

public class DestroyEffect : MonoBehaviour{
    public GameObject replacement;
    [HideInInspector]
    public bool dCheck = false;
    private Text coinTextField;
    [HideInInspector]
    public int multi = 1;

    void Start(){
        coinTextField = GameObject.Find("NoOfCoins").GetComponentInChildren<Text>();
        int NoOfCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        coinTextField.text = NoOfCoins.ToString();
    }
    
    void OnCollisionEnter(Collision collisionInfo){
        if (collisionInfo.collider.tag == "Obstacle"){
            FindObjectOfType<AudioManager>().obstacle();
            GameObject.Instantiate(replacement, transform.position, transform.rotation);
            Destroy(gameObject);
            dCheck = true;
            FindObjectOfType<GameManager>().EndGame();
            FindObjectOfType<RestartLevel>().coinsCollect();
        }
        else if(collisionInfo.collider.tag == "coin"){
            FindObjectOfType<AudioManager>().coin();
            int NoOfCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
            NoOfCoins += 1 * multi;
            Destroy(collisionInfo.gameObject);
            coinTextField.text = NoOfCoins.ToString();
            PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        }
        else if(collisionInfo.collider.tag == "Multiplyer"){
            FindObjectOfType<AudioManager>().multiplyer();
            multi = 2;
            Destroy(collisionInfo.gameObject);
            FindObjectOfType<Score>().multiplyer();
        }
    }
}
