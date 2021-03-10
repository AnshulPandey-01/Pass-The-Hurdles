using UnityEngine;
using UnityEngine.UI;

public class MessagePop : MonoBehaviour{
    public Text trueField;
    public GameObject messageBox, menu;

    public void onClickTrueBtn(){
        FindObjectOfType<PlayerSelecter>().ButtonSound();
        if(trueField.text=="Yes"){
            FindObjectOfType<PlayerSelecter>().unlock();
            messageBox.SetActive(false);
        }else if(trueField.text=="Ok"){
            menu.SetActive(true);
            messageBox.SetActive(false);
        }
    }

    public void onClickFalseBtn(){
        FindObjectOfType<PlayerSelecter>().ButtonSound();
        menu.SetActive(true);
        messageBox.SetActive(false);
    }
}
