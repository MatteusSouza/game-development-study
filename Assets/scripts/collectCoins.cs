using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    private GameObject[] coins;
    private void Start()
    {
        if (coins == null)
        {
            coins = GameObject.FindGameObjectsWithTag("coin");
        }
    }

    void Update()
    {
        playerManager.onRestartLevel += ResetCoinsPosition;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("coin") == true)
        {
            ScoreSystem.currentScore = ScoreSystem.currentScore + 1;
            col.gameObject.SetActive(false);
        }
    }

    void ResetCoinsPosition()
    {
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}
