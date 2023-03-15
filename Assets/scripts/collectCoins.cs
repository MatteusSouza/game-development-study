using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectCoins : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreTxt.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("coin") == true)
        {
            score = score + 1;
            Destroy(col.gameObject);
        }
    }
}
