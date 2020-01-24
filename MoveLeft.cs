using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Dit maakt een private float voor speed met als waarde 30.
    private float speed = 30;
    
    // Dit zorgt ervoor dat er informatie uit het script PlayerController kan worden gehaald.
    private PlayerController playerControllerScript;

    // Dit maakt een private float voor leftBound met als waarde -15.
    private float leftBound = -15;

    // Dit zorgt ervoor dat er wordt gezocht naar de player.
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Dit zorgt ervoor dat alles wat er tussen staat constant wordt uitgevoert.
    void Update()
    {
        // Dit zorgt ervoor dat als gameOver false is het altijd naar links gaat.
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Dit zorgt ervoor dat de obstacle wordt verwijderd als de positie kleiner is dan leftBound.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
