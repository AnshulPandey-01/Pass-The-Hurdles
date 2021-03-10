using UnityEngine;

public class SpwanFinal : MonoBehaviour{
    public Transform[] spawnPoints;
    public GameObject Obstacle3, Obstacle6, Obstacle9, Obstacle12, coin, multiplyer;
    private float nextSpawnTime = 1.8f, timeT = 0f, difficulty = 25f, timeLimit = 0;

    void Update(){
        if (FindObjectOfType<GameManager>().check == false){
            //spawing obstacle every nextSpawnTime seconds
            if(Time.timeSinceLevelLoad > timeT){
                spawn();
                timeT = Time.timeSinceLevelLoad + nextSpawnTime;
            }
            //Increasing difficulty by decreasing nextSpawnTime every 25 seconds
            if(Time.timeSinceLevelLoad > difficulty && nextSpawnTime>0.73f){
                nextSpawnTime -= 0.072f;
                difficulty += 25;
            }
        }
    }

    void spawn(){
        int randomIndex = Random.Range(0, 5);
        int coinProbability = Random.Range(0, 100);
        Vector3 coinPosition = this.transform.position;
        coinPosition.y += 0.5f;
        coinPosition.z -= 1.0f;
        if(randomIndex == 0){
            coinPosition.x = -6;
            Instantiate(Obstacle12, spawnPoints[0].position, Quaternion.identity);
            if(coinProbability <= 60)
                Instantiate(coin, coinPosition, Quaternion.identity);
            else if(coinProbability >= 95 && Time.timeSinceLevelLoad > timeLimit){
                Instantiate(multiplyer, coinPosition, Quaternion.identity);
                timeLimit = Time.timeSinceLevelLoad + 10f;
            }
        }else if(randomIndex == 1){
            coinPosition.x = -3;
            Instantiate(Obstacle3, spawnPoints[4].position, Quaternion.identity);
            Instantiate(Obstacle9, spawnPoints[5].position, Quaternion.identity);
            if(coinProbability <= 60)
                Instantiate(coin, coinPosition, Quaternion.identity);
            else if(coinProbability >= 95 && Time.timeSinceLevelLoad > timeLimit){
                Instantiate(multiplyer, coinPosition, Quaternion.identity);
                timeLimit = Time.timeSinceLevelLoad + 10f;
            }
        }else if(randomIndex == 2){
            Instantiate(Obstacle6, spawnPoints[1].position, Quaternion.identity);
            Instantiate(Obstacle6, spawnPoints[2].position, Quaternion.identity);
            if(coinProbability <= 60)
                Instantiate(coin, coinPosition, Quaternion.identity);
            else if(coinProbability >= 95 && Time.timeSinceLevelLoad > timeLimit){
                Instantiate(multiplyer, coinPosition, Quaternion.identity);
                timeLimit = Time.timeSinceLevelLoad + 10f;
            }
        }else if(randomIndex == 3){
            coinPosition.x = 3;
            Instantiate(Obstacle9, spawnPoints[7].position, Quaternion.identity);
            Instantiate(Obstacle3, spawnPoints[6].position, Quaternion.identity);
            if(coinProbability <= 60)
                Instantiate(coin, coinPosition, Quaternion.identity);
            else if(coinProbability >= 95 && Time.timeSinceLevelLoad > timeLimit){
                Instantiate(multiplyer, coinPosition, Quaternion.identity);
                timeLimit = Time.timeSinceLevelLoad + 10f;
            }
        }else if(randomIndex == 4){
            coinPosition.x = 6f;
            Instantiate(Obstacle12, spawnPoints[3].position, Quaternion.identity);
            if(coinProbability <= 60)
                Instantiate(coin, coinPosition, Quaternion.identity);
            else if(coinProbability >= 95 && Time.timeSinceLevelLoad > timeLimit){
                Instantiate(multiplyer, coinPosition, Quaternion.identity);
                timeLimit = Time.timeSinceLevelLoad + 10f;
            }
        }
        
    }
}
