using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cameraPos = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos.x = player.transform.position.x;
        cameraPos.z = player.transform.position.z;
        transform.position = cameraPos;
    }
}
