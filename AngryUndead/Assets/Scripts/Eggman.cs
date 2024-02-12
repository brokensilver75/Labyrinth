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
    [SerializeField] AudioSource deathAudio;
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
        
        if (ammoDropChance == 1)
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        deathAudio.Play();
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        
        agent.isStopped = true;
        yield return new WaitForSeconds(0.25f);       
        agent.isStopped = false;
        Destroy(gameObject);
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
