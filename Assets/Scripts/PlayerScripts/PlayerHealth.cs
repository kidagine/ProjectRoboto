using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

        public int startingHealth = 100;
        static public bool disableSpeed = false;
        static public int currentHealth;                                   
        static public Slider healthSlider;
        public Slider healthSliderReal;
        public Image damageImage;                                   
        public AudioClip deathClip;                                 
        public float flashSpeed = 5f;                               
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     
        public CanvasGroup canvasGroup;

        Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        PlayerMovement playerMovement;                              // Reference to the player's movement
        CharacterController2D characterController;
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               


        void Awake()
        {
     
            healthSlider = healthSliderReal;
            anim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
            playerMovement = GetComponent<PlayerMovement>();
            characterController = GetComponent<CharacterController2D>();
           

            // Set the initial health of the player.
            currentHealth = startingHealth;
        }

    void Hide()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }       
    void Update() { }
       



        public void TakeDamage(int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            playerAudio.Play();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
            }
        }


        public void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
       

            // Tell the animator that the player is dead.
            anim.SetTrigger("death");
            disableSpeed = true;
            

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            characterController.enabled = false;


        }
    }
