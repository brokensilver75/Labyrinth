using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class Eggman : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] float attackRange;
    //[SerializeField] GameObject blood;
    [SerializeField] GameObject ammoDrop;
    //[SerializeField] GameObject enemyShotty;
    [SerializeField] VisualEffect bloodFX;
    [SerializeField] Animator motaBhaiAnimator;
    bool playerInSightRange, playerInAttackRange;
    public Enemy motaBhai;
    private int ammoDropChance;

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
        motaBhai = new(sightRange, attackRange, timeBetweenAttacks, ammoDrop, false, motaBhaiAnimator);

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
        ChasePlayer();
        
    }

    private void ChasePlayer()
    {
        agent.destination = playerObject.transform.position; 
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(playerObject.transform);    
    }

    public void Onhit()
    {
        ammoDropChance = Random.Range(1, 5);
        StartCoroutine(Freeze());
        if (ammoDropChance == 1)
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Freeze()
    {
        agent.isStopped = true;
        motaBhaiAnimator.speed = 0;
        yield return new WaitForSeconds(3);
        motaBhaiAnimator.speed = 1;
        agent.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("PlayerLose");
        }
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
