using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRadius;
    [SerializeField] private float angle;
    [SerializeField] private GameObject BasicEnemy;
    private Transform TowerTransform;

    [SerializeField] private float timer;
    private float currentTimer;
    private GoldManager goldManager;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;
        TowerTransform = GameObject.FindGameObjectWithTag("Tower").GetComponent<Transform>();
        goldManager = GameObject.FindGameObjectWithTag("GoldManager").GetComponent<GoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer <= 0)
        {
            currentTimer = timer;
            GameObject g =Instantiate(BasicEnemy, GetPositionOnCircle(Random.Range(0,360)), transform.rotation);
             BasicEnemy_Gold bg = g.GetComponent<BasicEnemy_Gold>();
             bg.setGoldManager(goldManager);
            BasicEnemyMovement bem = g.GetComponent<BasicEnemyMovement>();
            bem.SetLookAtGameObject(TowerTransform);
        }
        else
        {
            currentTimer -= Time.deltaTime;
        }
    }

    private Vector3 GetPositionOnCircle(float angle)
    {
        return new Vector3(Mathf.Cos(angle) * spawnRadius + transform.position.x, 1, Mathf.Sin(angle) * spawnRadius + transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float theta = 0;
        float x = spawnRadius * Mathf.Cos(theta);
        float y = spawnRadius * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, 0, y);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = spawnRadius * Mathf.Cos(theta);
            y = spawnRadius * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }

}
