using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMovemnt : MonoBehaviour{
    private Animator animator;
    
    public float speed = .1f;

    public float xOffset;
    public float zOffset;

    public bool lockHorizontal = true;
    public bool lockVertical = true;

    public static int[,] offsetList = {{0, 1}, {-1, 0}, {0, -1}, {1, 0}};
      //{0, 1} Move North
      //{-1, 0} Move West
      //{0, -1} Move South
      //{1, 0} Move East

    public float turnSpeed = 20f;
    public int lastIndex = 0;
  
    void Start(){
      animator = GetComponent<Animator>();
    }
    
    void Update(){
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        if(CameraMovement.indexCounter == 0){
          xOffset = xDirection;
          zOffset = zDirection;
        } else if (CameraMovement.indexCounter == 2){
          xOffset = -xDirection;
          zOffset = -zDirection;
        } else if (CameraMovement.indexCounter == 1){
          xOffset = -zDirection;
          zOffset = xDirection;
        } else if (CameraMovement.indexCounter == 3){
          xOffset = zDirection;
          zOffset = -xDirection;
        }
        if (lockHorizontal == false || lockVertical == false){
          Vector3 moveDirection = new Vector3(xOffset, 0.0f, zOffset);
          transform.position += moveDirection * speed;
          animator.SetFloat("MoveSpeed", moveDirection.z);
          lastIndex = CameraMovement.indexCounter;
        }
    }
}
