using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletBehaviour : MonoBehaviour
{
    ParticleSystem bullet;
    Vector3 offset;
    private void Awake()
    {
        bullet = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("MotabhAI"))
        {
            other.gameObject.GetComponent<MotabhaiAI>().Onhit();
            other.gameObject.GetComponent<MotabhaiAI>().motaBhai.setDeathFlag(true);
        }

        if (other.CompareTag("Eggman"))
        {
            other.gameObject.GetComponent<Eggman>().Onhit();
            other.gameObject.GetComponent<Eggman>().motaBhai.setDeathFlag(true);
        }
    }
}
