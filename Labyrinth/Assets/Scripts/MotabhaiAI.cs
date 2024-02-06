using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.Animations;
using UnityEditor.Animations;
using Unity.VisualScripting;

public class MotabhaiAI : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] float attackRange;
    //[SerializeField] GameObject blood;
    [SerializeField] GameObject ammoDrop;
    [SerializeField] GameObject enemyShotty;
    [SerializeField] VisualEffect bloodFX;
    [SerializeField] Animator motaBhaiAnimator;
    bool playerInSightRange, playerInAttackRange;
    public Enemy motaBhai;

    //ATTACK
    public float timeBetweenAttacks;
    //bool alreadyAttacked;
    [SerializeField] private ParticleSystem bullet;
    


    private NavMeshAgent agent;
    private GameObject playerObject;

    [SerializeField] private LayerMask playerLayer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerObject = GameObject.Find("Player");
        motaBhai = new(sightRange, attackRange, timeBetweenAttacks, ammoDrop, enemyShotty.GetComponent<EnemyShotty>().getGun(), false, motaBhaiAnimator);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        //if (playerInSightRange && !playerInAttackRange)
        ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        agent.destination = playerObject.transform.position;
        
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(playerObject.transform);

        if (!motaBhai.getAlreadyAttacked())//getalreadyAttacked)
        {
            enemyShotty.GetComponent<EnemyShotty>().FireShotty();
            motaBhai.SetAlreadyAttacked();
            //alreadyAttacked = true;
            Invoke(nameof(ResetAttack), motaBhai.getTimeBetweenAttacks());
        }
    }

    private void ResetAttack()
    {
        motaBhai.ResetAttack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void Onhit()
    {
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        agent.isStopped = true;
        motaBhaiAnimator.speed = 0;
        yield return new WaitForSeconds(3);
        motaBhaiAnimator.speed = 1;
        agent.isStopped = false;
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(ammoDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }*/

    
    /*private void OnDestroy()
    {
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
    }*/
}
