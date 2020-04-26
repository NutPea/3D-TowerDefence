using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private Transform lookAtGameobject;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(lookAtGameobject != null){
        transform.LookAt(new Vector3(0, lookAtGameobject.transform.position.y, 0));
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(transform.position + forwardMovement);
    }

    public void SetLookAtGameObject(Transform lookAtGameobject)
    {
        this.lookAtGameobject = lookAtGameobject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tower")
        {
            TowerHealth th = other.gameObject.GetComponent<TowerHealth>();
            th.GetDamaged(1);

            Destroy(gameObject);
        }
    }

    
}
