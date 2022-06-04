using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float sensitivity;
    public KeyCode pickAndDrop;

    private Vector3 currPos = Vector3.zero;
    bool enterFruit;
    bool plucked;
    public Transform fruitPos;

    public float timeToEnableColider;

    public Animator AppleAnimator;

    public Sprite HandSprite;
    public Sprite GrabSprite;
    private SpriteRenderer _spriteRenderer;

    public Transform dummyTransform;
    public int firstOrderLayer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        fruitPos = null;
        firstOrderLayer--;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currPos.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currPos.x = 1;
        }
        else
        {
            currPos.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            currPos.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currPos.y = -1;
        }
        else
        {
            currPos.y = 0;
        }


        transform.position += currPos * sensitivity * Time.deltaTime;

        if (enterFruit && Input.GetKey(pickAndDrop))
        {
            if (fruitPos != null)
            {
                fruitPos.position = transform.position;
            }
            plucked = true;
        }
        else if (plucked)
        {
            GetComponent<Collider2D>().isTrigger = true;
            plucked = false;

            StartCoroutine(waitForCollider());
            if (fruitPos.GetComponent<Rigidbody2D>() == null)
            {
                fruitPos.gameObject.AddComponent<Rigidbody2D>();
            }
            
        }

        if (Input.GetKey(pickAndDrop))
        {
            _spriteRenderer.sprite = GrabSprite;
        }
        else
        {
            _spriteRenderer.sprite = HandSprite;
        }

        //Debug.Log(enterFruit); 

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.2f, transform.position, 0.2f);
        if (hit)
        {
            Debug.Log(hit.transform.name);
        }
        if(hit && Input.GetKey(pickAndDrop))
        {
            hit.transform.position = transform.position;
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Debug.Log("Called");

        enterFruit = true;
        fruitPos = collision.collider.transform;
        fruitPos.GetComponent<SpriteRenderer>().sortingOrder = firstOrderLayer + 1;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

            enterFruit = false;

    }

    

    IEnumerator waitForCollider()
    {
        yield return new WaitForSeconds(timeToEnableColider);
        GetComponent<Collider2D>().isTrigger = false;

    }
}