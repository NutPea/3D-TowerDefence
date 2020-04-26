using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private int goldAmount;
    // Start is called before the first frame update
    
    public void addGold(int goldAmount){
        this.goldAmount += goldAmount;
    }

    public int getGoldAmount(){
        return goldAmount;
    }
}
