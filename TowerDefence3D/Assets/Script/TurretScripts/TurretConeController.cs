using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConeController : MonoBehaviour
{
  [SerializeField] private List<GameObject> ListOfEnemyInCone  = new List<GameObject>();
  private bool refreshList;

  [SerializeField]private GameObject referezTurret;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy"){
           ListOfEnemyInCone.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag == "Enemy" && refreshList){
            ListOfEnemyInCone.Clear();
            ListOfEnemyInCone.Add(other.gameObject);
            refreshList = false;
        }
        
    }

    public List<GameObject> GetListOfEnemyInCone(){
        return ListOfEnemyInCone;
    }

    public void RefreshList(){
        refreshList =true;
    }

    public void setRefferentTurret(GameObject turret){
        this.referezTurret = turret;
    }
}
