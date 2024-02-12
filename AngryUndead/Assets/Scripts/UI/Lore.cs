using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lore : MonoBehaviour
{
    [SerializeField] Text LoreText;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowLore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowLore()
    {
        LoreText.text = "Tasked by the, Elder of your poor and sick village, you have finally breached through the doors of the Castle under the Mountains, armed with the holy LIGHT emitting Gun to Cull the evil. Get to the Treasure before the Demons protecting it get you and spread joy and happiness to your village.";
    }
}
