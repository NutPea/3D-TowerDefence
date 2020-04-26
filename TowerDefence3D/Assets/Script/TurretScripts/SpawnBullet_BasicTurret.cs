using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet_BasicTurret : MonoBehaviour
{

     [SerializeField] private GameObject BasicTurretBullet;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot){
            Instantiate(BasicTurretBullet,transform.position,transform.rotation);
            shoot = false;
        }
    }

    public void shootBullet(){
        shoot = true;
    }
}
