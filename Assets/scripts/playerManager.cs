using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    private Rigidbody2D player;
    private float movePlayer;
    public float speed, jumpForce, alturacamera, panelWinSpeed;
    private bool jump, isgrounded, restartPlayer, win;
    private GameObject cameraPos, inicialPos;
    public GameObject panelWin;
    public delegate void OnRestartLevel();
    public static OnRestartLevel onRestartLevel;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera");
        inicialPos = GameObject.Find("playerStartPosition");
        win = false;
    }

    void Update()
    {
        movePlayer = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        cameraPos.transform.position = new Vector3(
            cameraPos.transform.position.x,
            player.transform.position.y + alturacamera,
            cameraPos.transform.position.z
            );
        player.velocity = new Vector2(movePlayer * speed,player.velocity.y);
        if (jump == true && isgrounded == true && win == false)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isgrounded = false;
        }
        restartLevel();
        winGame();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            isgrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("armadilhas") == true)
        {
            restartPlayer = true;
        }
        if (col.CompareTag("win") == true)
        {
            win = true;
        }
    }
    private void restartLevel()
    {
        if(restartPlayer == true)
        {
            player.transform.position = new Vector2(
                inicialPos.transform.position.x,
                inicialPos.transform.position.y
                );
            restartPlayer = false;
            onRestartLevel?.Invoke();
        }
    }
    private void winGame()
    {
        if (win == true)
        {
            player.velocity = new Vector2(0,player.velocity.y);
            panelWin.transform.position = Vector2.MoveTowards(panelWin.transform.position,cameraPos.transform.position, panelWinSpeed * Time.deltaTime);
        }
    }
}
