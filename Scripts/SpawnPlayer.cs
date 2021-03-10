using UnityEngine;

public class SpawnPlayer : MonoBehaviour{
    public GameObject[] Players;

    void Start(){
        int player_no = PlayerPrefs.GetInt("character_no", 0);
        if(player_no==4){
            Instantiate(Players[player_no], transform.position, Players[player_no].transform.rotation);
        }else{
            Instantiate(Players[player_no], transform.position, Quaternion.identity);
        }
        FindObjectOfType<FollowPlayer>().Initializer();
    }
}
