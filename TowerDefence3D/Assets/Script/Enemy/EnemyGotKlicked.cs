using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGotKlicked : MonoBehaviour
{
    [SerializeField] private bool gotHitByMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public bool GetGotHitByMouse()
    {
        return gotHitByMouse;
    }

    public void getHited()
    {
        gotHitByMouse = true;

    }

    public void setGetHitedBack()
    {
        gotHitByMouse = false;
    }
}
