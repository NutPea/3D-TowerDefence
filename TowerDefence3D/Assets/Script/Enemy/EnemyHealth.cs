using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyGotKlicked enemyGotKlicked;
    [SerializeField] private int maxEnemyHealth;
    private int currentEnemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        enemyGotKlicked = GetComponent<EnemyGotKlicked>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (enemyGotKlicked.GetGotHitByMouse())
        {
            EnemyTakeDamage(2);
            enemyGotKlicked.setGetHitedBack();
        }
        //Enemy wird im jeweiligen Gold Add Script destroyed
    }

    public void EnemyTakeDamage(int damageAmount){
        currentEnemyHealth -= damageAmount;
    }

    public int getCurrentEnemyHealth(){
        return currentEnemyHealth;
    }
}
