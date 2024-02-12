using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contrpls : MonoBehaviour
{

    [SerializeField] Text Controls;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowControls);
    }

    private void ShowControls()
    {
        Controls.text = "W,S,A,D - To move\r\n\r\nAim and Shoot with Mouse";
    }
}
