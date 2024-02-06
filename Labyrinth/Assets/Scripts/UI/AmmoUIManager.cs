using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIManager : MonoBehaviour
{
    private string equippedGun;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        equippedGun = player.GetComponent<PlayerController>().getEquippedGun();
        GetComponent<Text>().text = "X" + player.transform.Find("Katta").GetComponent<Katta>().getGun().getAmmo();
        
    }
}