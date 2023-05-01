using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    [Header("Player Attributes")]
    [SerializeField] private float playerSpeed = 2;
    [SerializeField] private float jumpHeight = 4.5f;
    [SerializeField] private int maxNumOfJumps;
    [SerializeField] private PhotonView pv;
    private int jumps;
    private bool isJumping = false;
    private bool canJump = true;

    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
    public float Walking { get => walking; set => walking = value; }
    public KeyCode LeftWalkBtn { get => leftWalkBtn; set => leftWalkBtn = value; }
    public KeyCode RightWalkBtn { get => rightWalkBtn; set => rightWalkBtn = value; }
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
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
        if (pv.IsMine)
        {
            Jumping();
            if (CanMove)
            {
                Movement();
            }
            pv.RPC("UpdateLocation", RpcTarget.OthersBuffered, transform.position, transform.rotation);
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float horizontalMovement = PlayerSpeed * Time.deltaTime * horizontal;
        transform.Translate(horizontalMovement, 0, 0);
    }
    void Movement()
    {
        if (Input.GetKey(RightWalkBtn))
        {
            PlayerMovement();
            Walking = 1;
        }
        else if (Input.GetKey(LeftWalkBtn))
        {
            PlayerMovement();
            Walking = 2;
        }
        else
        {
            Walking = 0;
        }
        PlayerAnimator.SetFloat("Walking", Walking);
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

    [PunRPC]
    private void UpdateLocation(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ground")) 
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
