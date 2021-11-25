using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour{
    private Animator animator;
    public Transform target;
    
    public float speed = .1f;
    public float xOffset;
    public float zOffset;
    public float smoothSpeed = 0.125f;

    //public bool lockHorizontal = true;
    //public bool lockVertical = true;

    public static int indexCounter = 0;

    public static int[,] offsetList = {{0, 1}, {-1, 0}, {0, -1}, {1, 0}};
      //{0, 1} Move North
      //{-1, 0} Move West
      //{0, -1} Move South
      //{1, 0} Move East

    public float turnSpeed = 20f;
    public int lastIndex = 0;

    IEnumerator RotateMe(Vector3 byAngles, float inTime) {    
      var fromAngle = transform.rotation;
      var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
      for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
        transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
        yield return null;
      }
    }

    void Start(){
      animator = GetComponent<Animator>();
    }
    
    void Update(){
        
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        if(xDirection != 0 && zDirection != 0){
          zDirection = 0.0f;
        }
        
        bool cameraLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool cameraRight = Input.GetKeyDown(KeyCode.RightArrow);

        if(indexCounter == 0){
          xOffset = xDirection;
          zOffset = zDirection;
        } else if (indexCounter == 2){
          xOffset = -xDirection;
          zOffset = -zDirection;
        } else if (indexCounter == 1){
          xOffset = zDirection;
          zOffset = -xDirection;
        } else if (indexCounter == 3){
          xOffset = -zDirection;
          zOffset = xDirection;
        }

        Vector3 moveDirection = new Vector3(xOffset, 0.0f, zOffset);
        transform.position += moveDirection * speed;
        animator.SetFloat("MoveSpeed", moveDirection.z);
        lastIndex = CameraMovement.indexCounter;
        
        if(cameraRight == true){
            Debug.LogError("Right 90");
            indexCounter += 1;
                if (indexCounter > 3){
                    indexCounter = 0;
                }
            //transform.RotateAround(transform.position, new Vector3(0,1,0), 90);
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        if(cameraLeft == true){
            Debug.LogError("Left -90");
            indexCounter -= 1;
            if (indexCounter < 0){
                indexCounter = 3;
            }
          //transform.RotateAround(transform.position, new Vector3(0,1,0), -90);
          StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
        }

    }
}