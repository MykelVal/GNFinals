using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : PlayerLives
{
    //AnimatorVariables
    [SerializeField] private Animator playerAnimator;
    private float walking = 0;
    //PlayerVariables
    [Header("Key Codes")]
    [SerializeField] private KeyCode leftWalkBtn;
    [SerializeField] private KeyCode rightWalkBtn;
    [SerializeField] private KeyCode jumpBtn;
    [SerializeField] private KeyCode skillBtn;
    [Header("Player Attributes")]
    [SerializeField] private float playerSpeed = 2;
    [SerializeField] private float jumpHeight = 4.5f;
    [SerializeField] private int maxNumOfJumps;
    private int jumps;
    private bool isJumping = false;
    private bool canJump = true;

    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
    public float Walking { get => walking; set => walking = value; }
    public KeyCode LeftWalkBtn { get => leftWalkBtn; set => leftWalkBtn = value; }
    public KeyCode RightWalkBtn { get => rightWalkBtn; set => rightWalkBtn = value; }
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
    public KeyCode SkillBtn { get => skillBtn; set => skillBtn = value; }
    public bool CanJump { get => canJump; set => canJump = value; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        base.Start();
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    public virtual void Update()
    {
        base.Update();
        Jumping();
    }
    //Jumping
    void Jumping()
    {
        if (CanMove)
        {
            if (Input.GetKeyDown(jumpBtn) && canJump && !isJumping && jumps < maxNumOfJumps)
            {
                playerAnimator.SetBool("isJumping", true);
                jumps++;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Ame Variant")) 
        {
            jumps = 0;
            isJumping = false;
            playerAnimator.SetBool("isJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ground") && jumps == maxNumOfJumps)
        {
            isJumping = true;
        }
    }
}
