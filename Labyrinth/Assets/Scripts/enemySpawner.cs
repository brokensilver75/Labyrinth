using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotuSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> bhaiList;
    

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bhaiList[Random.Range(0,2)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
