using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectCoins : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    public GameObject coinPrefab;
    private GameObject[] coins;
    private void Start()
    {
        score = 0;
        if (coins == null)
        {
            coins = GameObject.FindGameObjectsWithTag("coin");
        }
    }

    void Update()
    {
        scoreTxt.text = score.ToString();
        playerManager.onRestartLevel += ResetScore;
        playerManager.onRestartLevel += ResetCoinsPosition;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("coin") == true)
        {
            score = score + 1;
            col.gameObject.SetActive(false);
        }
    }
    void ResetScore()
    {
        score = 0;
    }
    void ResetCoinsPosition()
    {
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}
