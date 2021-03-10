using UnityEngine;
using UnityEngine.UI;


public class PlayerSelecter : MonoBehaviour{
    public GameObject[] Character;
    public GameObject left, right, costBtn, menu;
    private GameObject currentCharacter;
    public AudioSource buttonSoundSource, musicSoundSource;
    public Text costTxt, coinField;
    private string[] charArray = {"Sphere", "Car", "Police Car", "f1Car"};
    private int[] costArray = {50, 500, 1000, 2000};
    private int character_no, soundState;
    private Vector3 sLoc;
    
    public int getCharacterNo(){
        return character_no;
    }

    void Start(){
        soundState = PlayerPrefs.GetInt("Sound", 1);
        MusicSound();
        character_no = PlayerPrefs.GetInt("character_no", 0);
        sLoc = new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z);

        if(character_no==0 || character_no==1){
            currentCharacter = Instantiate(Character[character_no], sLoc, Quaternion.identity);
        }else if(character_no==4){
            currentCharacter = Instantiate(Character[character_no], sLoc, Character[character_no].transform.rotation);
        }else{
            currentCharacter = Instantiate(Character[character_no], transform.position, Character[character_no].transform.rotation);
        }

        check();
        characterCostField();
    }

    private void MusicSound(){
        musicSoundSource.enabled = PlayerPrefs.GetInt("Music", 1) == 1 ? true : false;
    }

    public void ButtonSound(){
        if(soundState==1) buttonSoundSource.Play();
    }

    public void leftBtn(){
        if(character_no>0 && left.activeSelf){
            Destroy(currentCharacter);
            character_no--;
            if(character_no==0 || character_no==1){
                currentCharacter = Instantiate(Character[character_no], sLoc, Quaternion.identity);
            }else if(character_no==4){
                currentCharacter = Instantiate(Character[character_no], sLoc, Character[character_no].transform.rotation);
            }else{
                currentCharacter = Instantiate(Character[character_no], transform.position, Character[character_no].transform.rotation);
            }
            PlayerPrefs.SetInt("character_no", character_no);
            ButtonSound();
            check();
            characterCostField();
        }
    }

    public void rightBtn(){
        if(character_no<4 && right.activeSelf){
            Destroy(currentCharacter);
            character_no++;
            if(character_no==0 || character_no==1){
                currentCharacter = Instantiate(Character[character_no], sLoc, Quaternion.identity);
            }else if(character_no==4){
                currentCharacter = Instantiate(Character[character_no], sLoc, Character[character_no].transform.rotation);
            }else{
                currentCharacter = Instantiate(Character[character_no], transform.position, Character[character_no].transform.rotation);
            }
            PlayerPrefs.SetInt("character_no", character_no);
            ButtonSound();
            check();
            characterCostField();
        }
    }

    public void check(){
        if(character_no==0 && left.activeSelf){
            left.SetActive(false);
        }else if(character_no==4 && right.activeSelf){
            right.SetActive(false);
        }

        if(character_no<4 && !right.activeSelf){
            right.SetActive(true);
        }

        if(character_no>0 && !left.activeSelf){
            left.SetActive(true);
        }
    }

    public void characterCostField(){
        if(character_no==0){
            costBtn.SetActive(false);
        }
        else{
            for(int i = 1; i<5; i++){
                if(character_no==i){
                    int cs = PlayerPrefs.GetInt(charArray[i-1], costArray[i-1]);
                    if(cs!=0){
                        if(!costBtn.activeSelf){
                            costBtn.SetActive(true);
                        }
                        costTxt.text = cs.ToString();
                    }else if(costBtn.activeSelf && cs==0){
                        costBtn.SetActive(false);
                    }
                    break;
                }
            }
        }
    }

    public void wayToPop(){
        ButtonSound();
        int NoOfCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        if(NoOfCoins > costArray[character_no-1]){
            DialogBox("Unlock "+charArray[character_no-1]+"?", "Yes", "No");
        }else{
            DialogBox("You don't have enough coins.", "Ok", "Cancel");
        }
    }

    public GameObject messageBox;
    public Text messageTxt;
    public Text trueTxt;
    public Text falseTxt;

    public void DialogBox(string message, string trueStr, string falseStr){
        menu.SetActive(false);
        messageBox.SetActive(true);
        messageTxt.text = message;
        trueTxt.text = trueStr;
        falseTxt.text = falseStr;
    }

    public void unlock(){
        menu.SetActive(true);
        int NoOfCoins = PlayerPrefs.GetInt("NoOfCoins", 0);
        int remainCoins = NoOfCoins - costArray[character_no-1];
        coinField.text = remainCoins.ToString();
        PlayerPrefs.SetInt("NoOfCoins", remainCoins);
        PlayerPrefs.SetInt(charArray[character_no-1], 0);
        characterCostField();
    }
}
