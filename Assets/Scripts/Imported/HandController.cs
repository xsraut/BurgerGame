using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public float sensitivity;
    public KeyCode pickAndDrop;
    public Sprite HandSprite;
    public Sprite GrabSprite;
    private Vector3 currPos = Vector3.zero;
    private SpriteRenderer _spriteRenderer;
    public int firstOrderLayer;

    RaycastHit2D hit;
    public float circleCastRadius;
    private int results;

    public bool pick;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(pickAndDrop))
        {
            _spriteRenderer.sprite = GrabSprite;
            if (!pick) pick = true;
        }
        else
        {
            _spriteRenderer.sprite = HandSprite;
            if (pick) pick = false;
        }

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

        hit = Physics2D.CircleCast(transform.position, circleCastRadius, transform.position, circleCastRadius);
        if (hit && Input.GetKey(pickAndDrop))
        {
            hit.transform.position = transform.position;
            if (hit.transform.rotation != Quaternion.identity)
            {
                hit.transform.rotation = Quaternion.identity;
            }
            Debug.Log(hit.transform.name);
        }
    }
}
