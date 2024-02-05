using Cinemachine;
using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody playerRb;
    private float health;
    private string equippedGun = "Katta";
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject bullet;
    //[SerializeField] private ParticleSystem bulletParticle;
    [SerializeField] private Transform firePoint;
    //[SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject katta;
    private bool moving = false;
    private Vector3 direction, mouseDirection;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        //bulletParticle = GetComponentInChildren<ParticleSystem>();
        controls = new PlayerControls();
        health = 100;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (moving)
        {
            MovePlayer(direction);
        } 
    }


    private void MovePlayer( Vector3 moveDirection)
    {
        transform.position += (moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue input)
    {
        //Debug.Log("MOVED");
        
        moving = true;
        direction = input.Get<Vector3>();
        //playerRb.velocity = input.Get<Vector3>() * moveSpeed * Time.deltaTime;
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            mouseDirection = position - transform.position;
            // Ignore the height difference.
            mouseDirection.y = 0;

            // Make the transform look in the direction.
            if(!mouseDirection.AlmostZero())
            transform.forward = mouseDirection;
        }
    }

    private void OnFire()
    {
        //bulletParticle.Play();
        katta.GetComponent<Katta>().FireKatta();
        //Instantiate(bulletParticle, firePoint.position, firePoint.rotation);
    }
    
    public void takeDamage()
    {
        if (health >= 0)
        {
            health -= 10;
        }
        Debug.Log("HEALTH = " + health);        
    }

    public string getEquippedGun()
    {
        return equippedGun;
    }
}
