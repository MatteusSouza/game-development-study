using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaminaTrap : MonoBehaviour
{
    private float z;
    public float speed;
    public GameObject point1, point2;
    private Vector2 nextPosition;
    void Start()
    {
        nextPosition = point1.transform.position;
    }

    void Update()
    {
        rotationTrap();
        movingTrap();
    }

    private void rotationTrap()
    {
        z = z + Time.deltaTime * 1000;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    
    private void movingTrap()
    {
        if (transform.position == point1.transform.position)
        {
            nextPosition = point2.transform.position;
        }
        if (transform.position == point2.transform.position)
        {
            nextPosition = point1.transform.position;
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            nextPosition,
            speed * Time.deltaTime
            );
    }
}
