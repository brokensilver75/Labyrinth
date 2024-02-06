using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Button>().onClick.AddListener(LoadAgain);
    }

    void LoadAgain()
    {
        SceneManager.LoadScene("PlayerStuff");
    }
    
}
