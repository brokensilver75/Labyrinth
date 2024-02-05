using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotty : MonoBehaviour
{
    private Gun gun;
    [SerializeField] private ParticleSystem shottyFire;
        
    private void Awake()
    {
        gun = new Gun(10, 10, shottyFire);
    }
    
    public void FireShotty()
    {
        gun.FireEnemyGun();
    }

    public Gun getGun()
    {
        return gun;
    }
}
