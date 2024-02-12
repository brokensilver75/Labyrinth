using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    ParticleSystem bullet;

    private void Awake()
    {
        bullet = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        /*if (other.CompareTag("MotabhAI"))
        {
            other.gameObject.GetComponent<MotabhaiAI>().motaBhai.OnDeath(other.gameObject.transform.position);
            Debug.Log("Hit Eenemy");    
            Destroy(other.gameObject);
        }*/
        
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().takeDamage();
        }
    }
}
