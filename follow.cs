using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // Reference to the player GameObject
    public Vector3 offset; 
    void Start(){
target.transform.position=new Vector3(58.0f,1f,-10.0f);
offset=new Vector3(0.0f,0.6f,-1.6f);

    }// Offset from the player
    void LateUpdate()
    {
        // Check if the target (player) is valid
        if (target == null)
            return;

        // Update the camera's position to match the player's position plus the offset
        transform.position = target.transform.position + offset;
    }
}
