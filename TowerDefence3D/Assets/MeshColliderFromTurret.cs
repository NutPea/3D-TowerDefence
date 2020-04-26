using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshColliderFromTurret : MonoBehaviour
{

    [SerializeField] private List<GameObject> ListOfEnemyInCone;

    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            ListOfEnemyInCone.Add(other.gameObject);
        }
    }

    
}
