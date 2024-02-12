using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    [SerializeField] Text LoadingText;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadAgain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAgain()
    {
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("PlayerStuff");

        while (loadOperation != null)
        {
            LoadingText.text = "LOADING...";
            yield return null;
        }
    }
    
}
