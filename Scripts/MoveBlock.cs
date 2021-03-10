using UnityEngine;

public class MoveBlock : MonoBehaviour{
    private float forwardForce = -18f, difficultySpeed = 25f;
    
    void FixedUpdate(){
        //Move obstacles
        transform.Translate(Vector3.forward * Time.deltaTime * forwardForce);
        //Incresing difficulty every 25 seconds till 375 seconds
        if (Time.timeSinceLevelLoad > difficultySpeed && difficultySpeed <= 375f){
            forwardForce -= 1.1f;
            difficultySpeed += 25f;
        }
        //When player dies force zero
        if (FindObjectOfType<GameManager>().check == true){
            forwardForce = 0.0f;
        }
        //Destroying obstacle when it goes beyond -2 on z axis
        if(transform.position.z < -10.0f){
            Destroy(gameObject);
        }
    }
}
