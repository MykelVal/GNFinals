using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalliBehaviour : PlayerBehavior
{
    private bool isReaperMode = false;
    private float skillButtonTimeOut;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        skillButtonTimeOut = Time.time;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (CanMove)
        {
            Movement();
            Skill();
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
    void Skill()
    {
        if (Input.GetKeyDown(SkillBtn) && !isReaperMode && (Time.time - skillButtonTimeOut > 2f))
        {
            skillButtonTimeOut = Time.time;
            gameObject.tag = "Reaper Calli";
            isReaperMode = true;
            PlayerAnimator.SetTrigger("toReaper");
            PlayerAnimator.SetBool("isReaperMode", isReaperMode);
            CanJump = false;
            Movement();
        }
        else if (Input.GetKeyDown(SkillBtn) && isReaperMode && (Time.time - skillButtonTimeOut > 2f))
        {
            skillButtonTimeOut = Time.time;
            gameObject.tag = "Player";
            isReaperMode = false;
            PlayerAnimator.SetTrigger("toCalli");
            PlayerAnimator.SetBool("isReaperMode", isReaperMode);
            CanJump = true;
        }
    }
}
