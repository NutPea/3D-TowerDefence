using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.eulerAngles = new Vector3(0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime+transform.eulerAngles.y, 0);
    }
}
