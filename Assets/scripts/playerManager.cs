using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    private Rigidbody2D player;
    private float movePlayer;
    public float speed, jumpForce, alturacamera;
    private bool jump, isgrounded, restartPlayer;
    private GameObject cameraPos, inicialPos;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera");
        inicialPos = GameObject.Find("inicialPos");
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
        if (jump == true && isgrounded == true)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isgrounded = false;
        }
        restartLevel();
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
        }
    }
}
