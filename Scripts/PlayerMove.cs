using UnityEngine;

public class PlayerMove : MonoBehaviour{
    public Transform player;
    public Rigidbody rb;
    Vector3 prevPos = new Vector3();
    Vector3 currPos = new Vector3();

    void FixedUpdate(){

        if(FindObjectOfType<GameManager>().check==false){
            foreach(Touch t in Input.touches){
                if(t.phase == TouchPhase.Began){
                    prevPos = t.position;
                }
                if(t.phase == TouchPhase.Moved){
                    currPos = t.position;
                    float deltaX = currPos.x - prevPos.x;
                    bool swipedSideways = Mathf.Abs(deltaX) > 2.5f;
                    if (swipedSideways && player.position.x < 7 && player.position.x > -7){
                        if (deltaX < 0){
                            player.transform.Translate(-0.24f, 0, 0);
                            rb.AddForce(-19, 0, 0);
                        }
                        else if (deltaX > 0){
                            player.transform.Translate(0.24f, 0, 0);
                            rb.AddForce(19, 0, 0);
                        }
                    }
                    prevPos = currPos;
                }
            }
        }

        if (player.position.x >= 7){
            player.transform.Translate(-0.2f, 0, 0);
        }
        else if (player.position.x <= -7){
            player.transform.Translate(0.2f, 0, 0);
        }
    }

    public void Freeze(){
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
}
