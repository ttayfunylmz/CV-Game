using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject websitesPanel;
    [SerializeField] private GameObject experiencePanel;
    [SerializeField] private GameObject certificatesPanel;
    [SerializeField] private GameObject skillsPanel;
    [SerializeField] private GameObject contactPanel;
    [SerializeField] private GameObject educationPanel;
    [SerializeField] private GameObject referencesPanel;

    private float horizontalMovement;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private AudioSource doorOpenSFX;

    private Rigidbody2D rb2d;
    private Animator animator;

    private Animator aboutPanelAnimator;
    private Animator websitesPanelAnimator;
    private Animator experiencePanelAnimator;
    private Animator certificatesPanelAnimator;
    private Animator skillsPanelAnimator;
    private Animator contactPanelAnimator;
    private Animator educationPanelAnimator;
    private Animator referencesPanelAnimator;

    private void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        doorOpenSFX = GameObject.Find("AboutPanel").GetComponent<AudioSource>();

        aboutPanelAnimator = GameObject.Find("AboutPanel").GetComponent<Animator>();
        websitesPanelAnimator = GameObject.Find("WebsitesPanel").GetComponent<Animator>();
        experiencePanelAnimator = GameObject.Find("ExperiencePanel").GetComponent<Animator>();
        certificatesPanelAnimator = GameObject.Find("CertificatesPanel").GetComponent<Animator>();
        skillsPanelAnimator = GameObject.Find("SkillsPanel").GetComponent<Animator>();
        contactPanelAnimator = GameObject.Find("ContactPanel").GetComponent<Animator>();
        educationPanelAnimator = GameObject.Find("EducationPanel").GetComponent<Animator>();
        referencesPanelAnimator = GameObject.Find("ReferencesPanel").GetComponent<Animator>();
    }

    private void Update() 
    {
        Jump();
        
        if(horizontalMovement > 0 && !isFacingRight)
            FlipSprite();
        else if(horizontalMovement < 0 && isFacingRight)
            FlipSprite();
    }

    private void FixedUpdate() 
    {
        Movement();
    }

    private void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement * movementSpeed * Time.deltaTime, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb2d.velocity = Vector2.up * jumpSpeed;
        }

        //to check jump animation
        if(!isGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        if(isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void FlipSprite()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    //to prevent our player to air jump
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "AboutBookStand")
        {
            aboutPanel.SetActive(true);
            aboutPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
        
        if(other.gameObject.tag == "WebsitesBookStand")
        {
            websitesPanel.SetActive(true);
            websitesPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "ExperienceBookStand")
        {
            experiencePanel.SetActive(true);
            experiencePanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "CertificatesBookStand")
        {
            certificatesPanel.SetActive(true);
            certificatesPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "SkillsBookStand")
        {
            skillsPanel.SetActive(true);
            skillsPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "ContactBookStand")
        {
            contactPanel.SetActive(true);
            contactPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "EducationBookStand")
        {
            educationPanel.SetActive(true);
            educationPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
        if(other.gameObject.tag == "ReferencesBookStand")
        {
            referencesPanel.SetActive(true);
            referencesPanelAnimator.SetBool("isTriggered", true);
            doorOpenSFX.Play();
        }
            
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        /*aboutPanel.SetActive(false);
        websitesPanel.SetActive(false);
        experiencePanel.SetActive(false);
        certificatesPanel.SetActive(false);
        skillsPanel.SetActive(false);
        contactPanel.SetActive(false);
        educationPanel.SetActive(false);
        referencesPanel.SetActive(false);*/
        aboutPanelAnimator.SetBool("isTriggered", false);
        websitesPanelAnimator.SetBool("isTriggered", false);
        experiencePanelAnimator.SetBool("isTriggered", false);
        certificatesPanelAnimator.SetBool("isTriggered", false);
        skillsPanelAnimator.SetBool("isTriggered", false);
        contactPanelAnimator.SetBool("isTriggered", false);
        educationPanelAnimator.SetBool("isTriggered", false);
        referencesPanelAnimator.SetBool("isTriggered", false);
    }
}
