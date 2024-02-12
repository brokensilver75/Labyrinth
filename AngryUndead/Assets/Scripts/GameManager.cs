using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject gun;
    GameObject[] bullets;
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
        Debug.Log(gun.name);
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Debug.Log(bullets[i].name);
            bullets[i].GetComponent<Rigidbody>().velocity = gun.transform.forward * bulletSpeed;
        }
    }
}
