using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KattaAmmo : MonoBehaviour
{
    GameObject Player;
    Gun kattaGun;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        kattaGun = Player.transform.Find("Katta").GetComponent<Katta>().getGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            kattaGun.raiseAmmo();
            Destroy(gameObject);
        }
    }
}
