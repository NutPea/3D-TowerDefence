using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretController : MonoBehaviour
{

    [SerializeField] private List<GameObject> ListOfEnemyInCone;
    private TurretMeshSpawner turretMeshSpawner;
    private TurretConeController turretConeController;

    [SerializeField] private float rateOfFirePerSecond;
    private float currentRateOfFireTimer;

    [SerializeField] private GameObject currentTarget;
    [SerializeField]private EnemyHealth currentEnemyHealth;
    private BasicEnemyHealth basicEnemyHealth;

    [SerializeField] private int turretDamage;
    [SerializeField]private bool gotATarget;
    private bool listIsRefreshable;

    private Transform trailSpawner;
    // Start is called before the first frame update
    private SpawnBullet_BasicTurret spawnBullet_BasicTurret;
    void Start()
    {
        turretMeshSpawner = GetComponent<TurretMeshSpawner>();
        turretConeController = turretMeshSpawner.getTurretConeController();
        ListOfEnemyInCone = turretConeController.GetListOfEnemyInCone();
        trailSpawner = transform.GetChild(2);
        spawnBullet_BasicTurret = trailSpawner.gameObject.GetComponent<SpawnBullet_BasicTurret>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCourrentTarget();
        shootsAtEnemy();
    }

    private void shootsAtEnemy()
    {
        //Note: First we check if we have a Target from the ChangeCourrentTarget(LOL)
        // If we have one we will apply Damage To the
        if (gotATarget)
        {
        
            trailSpawner.LookAt(currentTarget.transform.position);
            if (currentRateOfFireTimer <= 0)
            {
                currentRateOfFireTimer = rateOfFirePerSecond;
                if(currentEnemyHealth.getCurrentEnemyHealth() > 0){
                spawnBullet_BasicTurret.shootBullet();
                currentEnemyHealth.EnemyTakeDamage(turretDamage);
                }
            }
            else
            {
                currentRateOfFireTimer -= Time.deltaTime;
            }
        }
    }

    private void ChangeCourrentTarget(){
        //Note: First we check that the Enemys in the Area are more than 0
        // then we check if the first Element is filled if its filled 
        //a Enemy Target got detected
            if(ListOfEnemyInCone.Count >0){

                if(ListOfEnemyInCone[0]==null ){

                    gotATarget = false;               
                    turretConeController.RefreshList();
                }
                else{

                    gotATarget = true;
                }
                if(gotATarget){

                    currentTarget = ListOfEnemyInCone[0] ;
                    currentEnemyHealth = currentTarget.GetComponent<EnemyHealth>();
                }
        }


    }

}
