using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOneBehaviour : MonoBehaviour
{
    [Header("Colllider")]
    [SerializeField] private PolygonCollider2D buttonNotPressedCollider;
    [SerializeField] private PolygonCollider2D buttonPressedCollider;
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer btnRenderer;
    [SerializeField] private Sprite btnPressed;
    [SerializeField] private Sprite btnNotPressed;
    [Header("Fence")]
    [SerializeField] private GameObject fence1;
    [SerializeField] private GameObject fence2;
    /*[SerializeField] private Animator buttonAnimation;*/
    void Start()
    {
        btnRenderer = gameObject.GetComponent<SpriteRenderer>();
        buttonNotPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
        buttonPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            buttonNotPressedCollider.enabled = !buttonNotPressedCollider.enabled;
            buttonPressedCollider.enabled = buttonPressedCollider.enabled;
            btnRenderer.sprite = btnPressed;
            fence1.GetComponent<SpriteRenderer>().enabled = false;
            fence1.GetComponent<PolygonCollider2D>().enabled = false;
            fence2.GetComponent<SpriteRenderer>().enabled = false;
            fence2.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            buttonNotPressedCollider.enabled = buttonNotPressedCollider.enabled;
            buttonPressedCollider.enabled = !buttonPressedCollider.enabled;
            btnRenderer.sprite = btnNotPressed;
            fence1.GetComponent<SpriteRenderer>().enabled = true;
            fence1.GetComponent<PolygonCollider2D>().enabled = true;
            fence2.GetComponent<SpriteRenderer>().enabled = true;
            fence2.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
}
