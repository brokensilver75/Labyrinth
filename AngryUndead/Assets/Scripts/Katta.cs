using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katta : MonoBehaviour
{
    private Gun gun;
    [SerializeField] private ParticleSystem kattaFire;
        
    private void Awake()
    {
        gun = new Gun(12, 12, kattaFire);
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
