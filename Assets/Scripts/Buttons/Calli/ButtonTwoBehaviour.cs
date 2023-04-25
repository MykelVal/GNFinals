using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTwoBehaviour : MonoBehaviour
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
    [SerializeField] private GameObject fence3;
    [SerializeField] private GameObject fence4;
    [SerializeField] private GameObject fence5;
    [SerializeField] private GameObject fence6;
    [SerializeField] private GameObject fence7;
    [SerializeField] private GameObject fence8;
    private void Start()
    {
        btnRenderer = gameObject.GetComponent<SpriteRenderer>();
        buttonNotPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
        buttonPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
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
            fence2.GetComponent<SpriteRenderer>().enabled = true;
            fence2.GetComponent<PolygonCollider2D>().enabled = true;
            fence3.GetComponent<SpriteRenderer>().enabled = false;
            fence3.GetComponent<PolygonCollider2D>().enabled = false;
            fence4.GetComponent<SpriteRenderer>().enabled = true;
            fence4.GetComponent<PolygonCollider2D>().enabled = true;
            fence5.GetComponent<SpriteRenderer>().enabled = false;
            fence5.GetComponent<PolygonCollider2D>().enabled = false;
            fence6.GetComponent<SpriteRenderer>().enabled = true;
            fence6.GetComponent<PolygonCollider2D>().enabled = true;
            fence7.GetComponent<SpriteRenderer>().enabled = false;
            fence7.GetComponent<PolygonCollider2D>().enabled = false;
            fence8.GetComponent<SpriteRenderer>().enabled = true;
            fence8.GetComponent<PolygonCollider2D>().enabled = true;
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
            fence2.GetComponent<SpriteRenderer>().enabled = false;
            fence2.GetComponent<PolygonCollider2D>().enabled = false;
            fence3.GetComponent<SpriteRenderer>().enabled = true;
            fence3.GetComponent<PolygonCollider2D>().enabled = true;
            fence4.GetComponent<SpriteRenderer>().enabled = false;
            fence4.GetComponent<PolygonCollider2D>().enabled = false;
            fence5.GetComponent<SpriteRenderer>().enabled = true;
            fence5.GetComponent<PolygonCollider2D>().enabled = true;
            fence6.GetComponent<SpriteRenderer>().enabled = false;
            fence6.GetComponent<PolygonCollider2D>().enabled = false;
            fence7.GetComponent<SpriteRenderer>().enabled = true;
            fence7.GetComponent<PolygonCollider2D>().enabled = true;
            fence8.GetComponent<SpriteRenderer>().enabled = false;
            fence8.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
