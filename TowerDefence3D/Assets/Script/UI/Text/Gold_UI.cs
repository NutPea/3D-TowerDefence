using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold_UI : MonoBehaviour
{

    private TextMeshProUGUI textMesh;
    private GoldManager goldManager;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        goldManager = GameObject.FindGameObjectWithTag("GoldManager").GetComponent<GoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Gold : " +goldManager.getGoldAmount();
    }
}
