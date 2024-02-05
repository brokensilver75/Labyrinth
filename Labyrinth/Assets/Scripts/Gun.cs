using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun 
{ 
    private int currentAmmo, totalAmmo;
    private ParticleSystem fire;

    public Gun(int totalBullets, int currentBullets, ParticleSystem gunFire)
    {
        totalAmmo = totalBullets;
        currentAmmo = currentBullets;
        fire = gunFire;
    }

    public void FireGun()
    {
        if(currentAmmo > 0)
        {
            fire.Play();
            currentAmmo--;
            Debug.Log(currentAmmo);
        }
    }

    public void FireEnemyGun()
    {
        fire.Play();
    }

    public void raiseAmmo()
    {
        currentAmmo += 5;
    }

    public int getAmmo()
    {
        return currentAmmo;
    }

}