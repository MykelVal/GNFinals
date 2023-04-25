using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    [Header("Toxic Clouds")]
    [SerializeField] private GameObject toxCloud1;
    [SerializeField] private SpriteRenderer toxCloud1Renderer;
    [SerializeField] private GameObject toxCloud2;
    [SerializeField] private SpriteRenderer toxCloud2Renderer;
    [SerializeField] private GameObject toxCloud3;
    [SerializeField] private SpriteRenderer toxCloud3Renderer;
    [SerializeField] private GameObject toxCloud4;
    [SerializeField] private SpriteRenderer toxCloud4Renderer;
    [SerializeField] private GameObject toxCloud5;
    [SerializeField] private SpriteRenderer toxCloud5Renderer;
    [SerializeField] private GameObject toxCloud6;
    [SerializeField] private SpriteRenderer toxCloud6Renderer;
    [SerializeField] private GameObject toxCloud7;
    [SerializeField] private SpriteRenderer toxCloud7Renderer;
    [SerializeField] private GameObject toxCloud8;
    [SerializeField] private SpriteRenderer toxCloud8Renderer;
    [SerializeField] private GameObject toxCloud9;
    [SerializeField] private SpriteRenderer toxCloud9Renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("FirstClue"))
        {
            Destroy(c.gameObject);
            StartCoroutine(ToxicCloud1GoneAnimation(2));
            Destroy(toxCloud1 , 2);
        }
        else if (c.gameObject.CompareTag("SecondClue"))
        {
            Destroy(c.gameObject);
            StartCoroutine(ToxicCloud2GoneAnimation(2));
            Destroy(toxCloud2, 2.1f);
            Destroy(toxCloud3, 2.1f);
        }
        else if (c.gameObject.CompareTag("ThirdClue"))
        {
            Destroy(c.gameObject);
            StartCoroutine(ToxicCloud3GoneAnimation(2));
            Destroy(toxCloud4, 2.1f);
            Destroy(toxCloud5, 2.1f);
        }
        else if (c.gameObject.CompareTag("FourthClue"))
        {
            Destroy(c.gameObject);
            StartCoroutine(ToxicCloud4GoneAnimation(2));
            Destroy(toxCloud6, 2.1f);
            Destroy(toxCloud7, 2.1f);
            Destroy(toxCloud8, 2.1f);
            Destroy(toxCloud9, 2.1f);
        }
    }
    public IEnumerator ToxicCloud1GoneAnimation(float waitTime)
    {
        var endtime = Time.time + waitTime;
        while (Time.time < endtime)
        {
            toxCloud1Renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            toxCloud1Renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator ToxicCloud2GoneAnimation(float waitTime)
    {
        var endtime = Time.time + waitTime;
        while (Time.time < endtime)
        {
            toxCloud2Renderer.enabled = false;
            toxCloud3Renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            toxCloud2Renderer.enabled = true;
            toxCloud3Renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator ToxicCloud3GoneAnimation(float waitTime)
    {
        var endtime = Time.time + waitTime;
        while (Time.time < endtime)
        {
            toxCloud4Renderer.enabled = false;
            toxCloud5Renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            toxCloud4Renderer.enabled = true;
            toxCloud5Renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator ToxicCloud4GoneAnimation(float waitTime)
    {
        var endtime = Time.time + waitTime;
        while (Time.time < endtime)
        {
            toxCloud6Renderer.enabled = false;
            toxCloud7Renderer.enabled = false;
            toxCloud8Renderer.enabled = false;
            toxCloud9Renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            toxCloud6Renderer.enabled = true;
            toxCloud7Renderer.enabled = true;
            toxCloud8Renderer.enabled = true;
            toxCloud9Renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
