using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientScript : MonoBehaviour
{
    public Transform targetPosition;
    public float distanceToPlate = 2;
    public float smooth;
    bool goToTargetBool = false;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, targetPosition.position) <= distanceToPlate)
        {
            goToTargetBool = true;
        }
        else
        {
            goToTargetBool = false;
        }

        if (goToTargetBool && FindObjectOfType<HandController>().pick == false)
        {
            Debug.Log("Lerping");
            transform.position = Vector2.Lerp(transform.position, targetPosition.position + offset, smooth * Time.deltaTime);
            GetComponent<CapsuleCollider2D>().enabled = false;

            if (Vector2.Distance(transform.position,targetPosition.position + offset)<0.05f)
            {
                FindObjectOfType<level1>().increasePointer();
                GetComponent<ingredientScript>().enabled = false;
            }
        }

        

        
    }
}
