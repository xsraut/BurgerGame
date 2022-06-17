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

    int screenSizeH;
    int screenSizeV;
    Camera cam;
    [SerializeField]
    Vector3 cursorSizeOffset;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        screenSizeH = Screen.width;
        screenSizeV = Screen.height;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.WorldToScreenPoint(transform.position));

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

        if (Input.GetKey(KeyCode.A) && cam.WorldToScreenPoint(transform.position).x > (0 + cursorSizeOffset.x))
        {
            currPos.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) && cam.WorldToScreenPoint(transform.position).x < (screenSizeH - cursorSizeOffset.y))
        {
            currPos.x = 1;
        }
        else
        {
            currPos.x = 0;
        }

        if (Input.GetKey(KeyCode.W) && cam.WorldToScreenPoint(transform.position).y < (screenSizeV - cursorSizeOffset.y))
        {
            currPos.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) && cam.WorldToScreenPoint(transform.position).y > (0 + cursorSizeOffset.y))
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
