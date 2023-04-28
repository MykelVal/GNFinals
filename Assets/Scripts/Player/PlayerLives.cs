using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerLives : MonoBehaviourPun
{
    //AnimatorVariables
    private bool playerIsInvincible = false;
    private int playerLifeCount = 3;
    private bool playerIsDead = false;
    public bool canMove = true;
    [Header("Lives")]
    [SerializeField] private GameObject playerFirstLife;
    [SerializeField] private GameObject playerSecondLife;
    [SerializeField] private GameObject playerThirdLife;
    [SerializeField] private SpriteRenderer playerRenderer;
    [Header("Animators")]
    [SerializeField] private Animator playerHurtOrGameOverAnimator;
    public int PlayerLifeCount { get => playerLifeCount; set => playerLifeCount = value; }
    public bool CanMove { get => canMove; set => canMove = value; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        PlayerDamagedByEnemy();
    }
    void PlayerDamagedByEnemy()
    {
        if (playerLifeCount < 3)
        {
            Destroy(playerThirdLife);
        }
        if (playerLifeCount < 2)
        {
            Destroy(playerSecondLife);
        }
        if (playerLifeCount < 1)
        {
            Destroy(playerFirstLife);
            
            playerHurtOrGameOverAnimator.SetBool("isDead", true);
            canMove = false;
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        if (!playerIsInvincible)
        {
            if (c.gameObject.CompareTag("Obstacles"))
            {
                playerLifeCount--;
                if(playerLifeCount == 0)
                {
                    playerIsDead = true;
                }
                StartCoroutine(playerInvinsibiltyAnimation(2));
            }
        }
    }
    public IEnumerator playerInvinsibiltyAnimation(float waitTime)
    {
        if (!playerIsDead)
        {
            playerHurtOrGameOverAnimator.SetBool("LoseLife", true);
            playerIsInvincible = true;
            var endtime = Time.time + waitTime;
            while (Time.time < endtime)
            {
                playerRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
                playerRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            playerIsInvincible = false;
            playerHurtOrGameOverAnimator.SetBool("LoseLife", false);
        }
    }
}
