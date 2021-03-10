using UnityEngine;

public class FollowPlayer : MonoBehaviour{
    private GameObject player;
    public Vector3 offset;
    
    public void Initializer() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void LateUpdate(){
        if (FindObjectOfType<GameManager>().check == false){
            transform.position = player.transform.position + offset;
        }
    }
}
