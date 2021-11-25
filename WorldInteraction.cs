/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{
    void Start(){
        
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
            GetInteraction();
        }
    }

    void GetInteraction(){
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RayCastHit interactionInfo;
        if(Physics.RayCast(interactionRay, out interactionInfo, Mathf.Infinity)){
            GameObject  interactedObject = interactionInfo.collider.gameObject(); 
            if(interactedObject.tag == "Interacted Object"){
                Debug.Log("Interactable Hit :)");
            } else {

            }
        }
    }
}
*/