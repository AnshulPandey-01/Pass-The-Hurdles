using UnityEngine;

public class coin : MonoBehaviour{
    private float rotSpeed = -5f, forwardForce = -18f, difficultySpeed = 25f;

    void FixedUpdate(){
        transform.position += Vector3.forward * forwardForce * Time.deltaTime;
        transform.Rotate(0, rotSpeed, 0);
        //Incresing coin spedd every 25 seconds till 375 seconds for difficulty
        if (Time.timeSinceLevelLoad > difficultySpeed && difficultySpeed <= 375f){
            forwardForce -= 1.1f;
            difficultySpeed += 25f;
        }
        //When player dies force zero
        if (FindObjectOfType<GameManager>().check == true){
            forwardForce = 0.0f;
        }
        //Destroying coin when it goes beyond -2 on z axis
        if(transform.position.z < -10.0f){
            Destroy(gameObject);
        }
    }
}
