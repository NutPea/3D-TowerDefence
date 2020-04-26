using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BasicTurret : MonoBehaviour
{

    private Rigidbody rigidbody;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 forwardMovement = transform.forward * Time.deltaTime * speed ;
       rigidbody.MovePosition(transform.position+forwardMovement);
       
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject){
            Destroy(gameObject);
        }
    }
}
