using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int scoreInt = 0;

    //List texts :
    [SerializeField] Text[] listText;
    public Color normalListTextColor;
    public Color highlitedListTextColor;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i< listText.Length; i++)
        {
            listText[i].color = normalListTextColor;
        }
        listText[0].fontStyle = FontStyle.Bold;
        listText[0].color = highlitedListTextColor;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreInt.ToString();
    }

    public void IncreaseScore()
    {
        scoreInt++;
        for (int i = 0; i < listText.Length; i++)
        {
            listText[i].color = normalListTextColor;
            listText[i].fontStyle = FontStyle.Normal;
        }
        if (scoreInt < 5)
        {
            listText[scoreInt].fontStyle = FontStyle.Bold;
            listText[scoreInt].color = highlitedListTextColor;
        }
    }
}
