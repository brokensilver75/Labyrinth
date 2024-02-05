using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katta : MonoBehaviour
{
    private Gun gun;
    [SerializeField] private ParticleSystem kattaFire;
        
    private void Awake()
    {
        gun = new Gun(10, 10, kattaFire);
    }
    
    public void FireKatta()
    {
        gun.FireGun();
    }

    public Gun getGun()
    {
        return gun;
    }
}
