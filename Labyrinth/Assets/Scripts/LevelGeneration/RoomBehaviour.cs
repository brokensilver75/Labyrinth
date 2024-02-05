using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    // 0 - Up 1 -Down 2 - Right 3- Left
    public GameObject[] walls; 
    public GameObject[] doors;
    private int chance = 0;

    public void UpdateRoom(bool[] status)
    {
        chance = Random.Range(0, 2);
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);

            walls[i].SetActive(!status[i]);

            if (status[i])
            {
                if(chance > 0)
                {
                    doors[i].SetActive(false);
                    walls[i].SetActive(false);
                }
            }
        }
    }
}