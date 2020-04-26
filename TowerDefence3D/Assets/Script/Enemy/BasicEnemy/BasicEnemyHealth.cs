using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{

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
            Destroy(gameObject);
            enemyGotKlicked.setGetHitedBack();
        }

        if(currentEnemyHealth <=0){
            Destroy(gameObject);
            Debug.Log(gameObject.name);
        }
    }

    public void EnemyTakeDamage(int damageAmount){
        currentEnemyHealth -= damageAmount;
    }

}
