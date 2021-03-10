using UnityEngine;

public class ArrowBtn : MonoBehaviour{
    
    public void leftArrow(){
        FindObjectOfType<PlayerSelecter>().leftBtn();
    }

    public void rightArrow(){
        FindObjectOfType<PlayerSelecter>().rightBtn();
    }

    public void costBtn(){
        FindObjectOfType<PlayerSelecter>().wayToPop();
    }
}
