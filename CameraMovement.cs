using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    public Transform target;
    
    public static Vector3[] offsetValues = new [] {new Vector3(0f, 5f, -5f),new Vector3(5f, 5f, 0f),new Vector3(0f, 5f, 5f),new Vector3(-5f, 5f, 0f)};
        //{0, 5, -5} Forward
        //{5, 5, 0} Right
        //{0, 5, 5} Backwards
        //{-5, 5, 0} Left
        //Goes counter clockwise

    public float smoothSpeed = 0.125f;
    public Vector3 offset = offsetValues[0];
    public static int indexCounter = 0;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate(){
        bool cameraLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool cameraRight = Input.GetKeyDown(KeyCode.RightArrow);
        
        if(cameraRight == true){
            Debug.LogError("Right " + offset);
            indexCounter += 1;
                if (indexCounter > 3){
                    indexCounter = 0;
                }
        }
        if(cameraLeft == true){
            Debug.LogError("Left" + offset);
            indexCounter -= 1;
            if (indexCounter < 0){
                indexCounter = 3;
            }
        }

        offset = offsetValues[indexCounter]; 

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed); 
        transform.position = smoothedPosition; 

        transform.LookAt(target);
    }
        
            
}

