using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacementController : MonoBehaviour
{

    [SerializeField] GameObject placeAbleObjectPrefab;
     private bool placeObject;
    private bool placeAbleGround;
    private GameObject currentPlaceableObject;
    private GameObject parentOfCurrentPlaceableObject;
    private TurretMeshSpawner turretMeshSpawner;

    void Update()
    {
       HandleSpawn();
       if(currentPlaceableObject != null){
           MoveCurrentlyObject();
           RealeseIfClicked();
       }
    }

    private void HandleSpawn()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            placeObject = true;
        }
        if (placeObject)
        {
            if(currentPlaceableObject == null){ 
                // Later we need to make it variable so you can change the turrets you want to place
                currentPlaceableObject = Instantiate(placeAbleObjectPrefab);
                parentOfCurrentPlaceableObject = currentPlaceableObject.transform.parent.gameObject;
                turretMeshSpawner = currentPlaceableObject.GetComponent<TurretMeshSpawner>();
            }
            else{
                Destroy(parentOfCurrentPlaceableObject);
            }
            placeObject = false;
        }
    }

    void MoveCurrentlyObject(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){

            if(hit.transform.gameObject.tag == "Tower"){
                //Code for Placing Turret at the Tower
                currentPlaceableObject.transform.position = hit.point;
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward,hit.normal); 
                placeAbleGround = true;
            }
            else{
                //Code for not placeable ground (make turret red)
                currentPlaceableObject.transform.position = hit.point;
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up,hit.normal);
                placeAbleGround = false;
            }

        }
    }

    void RealeseIfClicked(){
        
        if(Input.GetMouseButtonDown(0) && placeAbleGround){
            currentPlaceableObject = null;
            parentOfCurrentPlaceableObject=null;
            turretMeshSpawner.setTurretIsSet(true);
            turretMeshSpawner = null;
        }
    }
    
}
