using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    bool baseBun;
    bool lettuce;
    bool patty;
    bool onion;
    bool topBun;

    public Animator guideTextAnimator;
    public float yOffset;

    public GameObject[] ingredientsByOrder;
    int pointer = 0;

    public int orderInLayer = 2;

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < ingredientsByOrder.Length; i++)
        {
            ingredientsByOrder[i].GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer < ingredientsByOrder.Length)
        {
            if (!ingredientsByOrder[pointer].GetComponent<CapsuleCollider2D>().enabled)
            {
                ingredientsByOrder[pointer].GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }

    public void increasePointer()
    {
        if (pointer < ingredientsByOrder.Length)
        {
            pointer++;
            guideAnim();
            ingredientsByOrder[pointer].GetComponent<SpriteRenderer>().sortingOrder += pointer;
            ingredientsByOrder[pointer].GetComponent<ingredientScript>().offset.y += pointer * yOffset;
        }
    }   

    void guideAnim()
    {
        string boolName = "text" + (pointer).ToString();
        guideTextAnimator.SetBool(boolName, true);
    }
}
