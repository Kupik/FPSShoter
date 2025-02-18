using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CharacterMovment : MonoBehaviour
{
    private Dictionary<string, AudioClip> suneteActiuni = new Dictionary<string, AudioClip>();
    public AudioSource audioSource;
    public List<SoundAction> soundActions;
    private string currentSound = null;
    public Animator animator;
    public float moveSpeed = 2f;  // Viteza de mișcare
    public float moveRun = 6f; // Viteza de fugire
    public float jumpHeight = 2f; // Inaltimea jump
    public float gravity = -9.81f; // Gravitatia aplicată
    private CharacterController _controller;
    private Vector3 _velocity; // Viteza personajului

    private bool isGrounded;
    private bool canMove = true;

    // animator bool
    private bool isMove = false;
    private bool isRun = false;
    private bool isJump = false;


    [System.Serializable]
    public class SoundAction
    {
        public string actionName;
        public AudioClip soundClip;
    }


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();

        foreach (var action in soundActions)
        {
            suneteActiuni.Add(action.actionName, action.soundClip);
        }

    }

    public void SetCanMove(bool state)
    {
        canMove = state;
    }

    public void Update()
    {


        // verificam dacă personajul este pe sol
        isGrounded = _controller.isGrounded;


        Vector2 moveInput = UserInput.instance.MoveInput; 

        bool isRunning = UserInput.instance.RunReleased;

        float currentSpeed = isRunning ? moveRun : moveSpeed;




        // Directia de mișcare
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;



        // Aplicam miscarea orizontala
        _controller.Move(moveDirection * currentSpeed * Time.deltaTime);


        isMove = moveInput.magnitude > 0;
        isRun = isMove && isRunning;

        animator.SetBool("Walk", isMove && !isRunning && isJump);
        animator.SetBool("WalkRun", isRun || isRun && isJump);


        if (isMove && !isRunning && !isJump)
        {
            if (currentSound != "WalkSound")
            {
                PlaySound("WalkSound");
                currentSound = "WalkSound";
            }
        }
        else if (isRun && !isJump)
        {
            if (currentSound != "RunSound")
            {
                PlaySound("RunSound");
                currentSound = "RunSound";
            }
        }
        else if (isJump)
        {
            if (currentSound != "JumpSound")
            {
                PlaySound("JumpSound", 1.7f);
                currentSound = "JumpSound";
            }
        }
        else
        {
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    currentSound = null;
                }
            }
        }


     

        // Aplicăm săritură
        if (isGrounded && UserInput.instance.JumpJustPressed)
        {

            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // calcul de viteza a Playerului
            isJump = true;

            animator.SetBool("Jump", true);


        }
        else if (isGrounded)
        {
            isJump = false;
            animator.SetBool("Jump", false);



        }
        // Aplicăm gravitația
        if (!isGrounded)
        {
            _velocity.y += gravity * Time.deltaTime; //Gravitatia il va apasa pe personaj atunci cind el nu va fi pe sol
        }
        else if (_velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _controller.Move(_velocity * Time.deltaTime);


        if (isJump)
        {
            animator.SetBool("Jump", true);


        }
        else if (isMove || isRun)
        {
            animator.SetBool("Jump", false);




        }
    }
    public void PlaySound(string action, float pitch = 1.0f)
    {
        if (suneteActiuni.ContainsKey(action))
        {
            AudioClip clip = suneteActiuni[action];

            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.loop = true; // permite repetarea suntului de mai multe ori
                audioSource.pitch = pitch;
                audioSource.Play();
            }
            else if (!audioSource.isPlaying)
            {
                audioSource.Play(); // daca sunetu e setat il repornim
            }
        }
        else
        {
            Debug.LogWarning("Sunetul pentru actiune nu  a fost gasit");
        }
    }

}