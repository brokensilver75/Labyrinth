using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy
{
    float sightRange, attackRange, timebetweenAttacks;
    Gun gun;
    float dropChance = 0;
    public Animator enemyAnimator;

    //DeathFlag
    bool isDead;
    
    GameObject ammoDrop;
    bool alreadyAttacked = false;

    


    public void AmmoDrop(Vector3 position)
    {
        Object.Instantiate(ammoDrop, position, Quaternion.identity);
    }

    public void SetAlreadyAttacked()
    {
        
        alreadyAttacked = true;
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public bool getAlreadyAttacked()
    {
        return alreadyAttacked;
    }

    public float getTimeBetweenAttacks()
    {
        return timebetweenAttacks;
    }

    /*public void OnDeath(Vector3 position)
    {
        //dropChance = Random.Range(0, 2);
        //if (dropChance != 0)
        //Object.Instantiate(ammoDrop, position, Quaternion.identity);
        enemyAnimator.SetBool("isMoving", false);
        enemyAnimator.SetBool("isDead", true);
        //enemyAnimator.speed = 0;
        
    }*/

    public bool getDeathFlag()
    {
        return isDead;
    }

    public void setDeathFlag(bool deathFlag)
    {
        isDead = deathFlag;
    }

    public Enemy(float sightRange, float attackRange, float timeBetweenAttacks, GameObject ammoDrop, Gun gun, bool isDead, Animator enemyAnimator)
    {
        this.sightRange = sightRange;
        this.attackRange = attackRange;
        this.timebetweenAttacks = timeBetweenAttacks;
        this.ammoDrop = ammoDrop;
        this.gun = gun;
        this.isDead = isDead;
        this.enemyAnimator = enemyAnimator;
    }
}
