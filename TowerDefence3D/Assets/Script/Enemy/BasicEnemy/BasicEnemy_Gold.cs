using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy_Gold : MonoBehaviour
{

   [SerializeField] private GoldManager goldManager;
    private EnemyHealth enemyHealth;
    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.getCurrentEnemyHealth() <= 0){

            goldManager.addGold(2);
            Destroy(gameObject);
        }
    }

    public void setGoldManager(GoldManager goldManager){
        this.goldManager = goldManager;
    }
}
