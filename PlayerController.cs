using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    
    private Animator playerAnim;

    private AudioSource playerAudio;

    // Dit zorgt ervoor dat je in Unity een audioclip kan selecteren voor springen.
    public AudioClip jumpSound;

    // Dit zorgt ervoor dat je in Unity een audioclip kan selecteren voor crashen.
    public AudioClip crashSound;
    
    // Dit zorgt ervoor dat je in Unity een animatie kan selecteren voor de explosie.
    public ParticleSystem explosionParticle;
    
    // Dit zorgt ervoor dat je in Unity een animatie kan selecteren voor het lopen.
    public ParticleSystem dirtParticle;
    
    // Dit maakt een nieuwe float zodat we jumpForce een waarde kunnen geven in Unity met als standaard waarde 10.
    public float jumpForce = 10;
    
    // Dit maakt een nieuwe float zodat we gravityModifier een waarde kunnen geven in Unity.
    public float gravityModifier;

    // Dit maakt een nieuwe bool zodat we isOnground een waarde kunnen geven in Unity met als staandaard waarde true.
    public bool isOnGround = true;

    // Dit maakt een nieuwe bool voor gameOver.
    public bool gameOver;
    
    void Start()
    {
        // Dit geeft aan wat playerRb is.
        playerRb = GetComponent<Rigidbody>();
        
        // Dit geeft aan wat playerAnim is.
        playerAnim = GetComponent<Animator>();

        // Dit geeft aan wat playerAudio is.
        playerAudio = GetComponent<AudioSource>();
        
        // Dit zorgt ervoor dat we de gravity kunnen aanpassen.
        Physics.gravity *= gravityModifier;
    }

    // Dit zorgt ervoor dat alles wat er tussen staa constant wordt uitgevoert.
    void Update()
    {
        // deze if statement zorgt ervoor dat als spatie wordt ingedrukt je springt en dat je alleen kan springen als je op de grond staat en leeft.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // Dit zorgt ervoor dat de jump animatie triggered en de audio klopt.
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Dit zorgt ervoor dat de waarde van isOnGround true wordt als de speler springt en weer op de grond terecht komt. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        
        // Dit zorgt ervoor dat als de speler game over is als je een obstacle.
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            
            // Dit zorgt ervoor dat je death animatie krijgt en de audio klopt.
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
