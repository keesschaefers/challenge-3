using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Dit zorgt ervoor dat we een prefab kunnen selecteren in Unity.
    public GameObject obstaclePrefab;
    
    // Dit zorgt ervoor dat er een positie wordt gekozen waar de prefab spawned.
    private Vector3 spawnPos = new Vector3(25,0, 0);

    // Dit zorgt ervoor dat er een spawndelay en spawnrate is met als waarde 2.
    private float startDelay = 2;
    private float repeatRate = 2;
    
    // Dit zorgt ervoor dat er informatie uit het script PlayerController kan worden gehaald.
    private PlayerController playerControllerScript;
    
    void Start()
    {
        // Dit zorgt ervoor dat er wordt gezocht naar de player.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        // Dit zorgt ervoor dat de obstacles spawnen met een delay.
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);   
    }
    
    // Dit is het script dat de obstacles spawned.
    void SpawnObstacle()
    {
        // Dit zorgt ervoor dat als gameOver false is er geen obstacles worden gespawned.
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
