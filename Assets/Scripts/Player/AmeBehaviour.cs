using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeBehaviour : PlayerBehavior
{
    [Header("Variant Variables")]
    [SerializeField] private Animator portalAnimator;
    [SerializeField] private Transform variantSpawnPoint;
    private GameObject variantPortal;
    private GameObject ameVariantAnim;
    [Header("Prefab")]
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject ameVariant;
    [SerializeField] private GameObject byeVarAmeAnimation;
    private float skillButtonTimeOut;
    private bool variantIsActive = false;
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
        float horizontal = Input.GetAxis("Arrow Horizontal");
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
        if (Input.GetKeyDown(SkillBtn) && !variantIsActive && (Time.time - skillButtonTimeOut > 2f))
        {
            skillButtonTimeOut = Time.time;
            variantIsActive = true;
            variantPortal = Instantiate(portal, variantSpawnPoint.position, Quaternion.identity);
            Destroy(variantPortal, 2f);
            Invoke("AmeVariantAnimation", 1.9f);
            Invoke("ByeVarAmeAnimation", 7.9f);
        }
        else if (variantIsActive && (Time.time - skillButtonTimeOut > 2f))
        {
            skillButtonTimeOut = Time.time;
            variantIsActive = false;
        }
    }
    void AmeVariantAnimation()
    {
        ameVariantAnim = Instantiate(ameVariant, variantPortal.transform.position, Quaternion.identity);
        Destroy(ameVariantAnim, 6.1f);
    }
    void ByeVarAmeAnimation()
    {
        GameObject g = Instantiate(byeVarAmeAnimation, ameVariantAnim.transform.position, Quaternion.identity);
        Destroy(g, 1.1f);
    }
}
