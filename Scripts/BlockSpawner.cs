using UnityEngine;

public class BlockSpawner : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject Obstacle3, Obstacle6, Obstacle9, Obstacle12;
    
    void Start(){
        spawn();
    }

    void spawn(){
        int randomIndex = Random.Range(0, 5);
        if(randomIndex == 0){
            Instantiate(Obstacle12, spawnPoints[0].position, Quaternion.identity);
        }else if(randomIndex == 1){
            Instantiate(Obstacle3, spawnPoints[4].position, Quaternion.identity);
            Instantiate(Obstacle9, spawnPoints[5].position, Quaternion.identity);
        }else if(randomIndex == 2){
            Instantiate(Obstacle6, spawnPoints[1].position, Quaternion.identity);
            Instantiate(Obstacle6, spawnPoints[2].position, Quaternion.identity);
        }else if(randomIndex == 3){
            Instantiate(Obstacle9, spawnPoints[7].position, Quaternion.identity);
            Instantiate(Obstacle3, spawnPoints[6].position, Quaternion.identity);
        }else if(randomIndex == 4){
            Instantiate(Obstacle12, spawnPoints[3].position, Quaternion.identity);
        }
    }
}
