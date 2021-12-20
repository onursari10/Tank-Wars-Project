using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    Rigidbody enemyTank;

    float posX;
    float posZ;

    float posMin = 724;

    Vector3 targetPos;

    public float speedMove = 0.05f;
    public float speedRotate = 0.1f;

     void Awake()
    {
        enemyTank = GetComponent<Rigidbody>();
    }

    void Start()
    {
        getNewPosition();
    }

    void getNewPosition()
    {
        posX = Random.Range(-posMin, posMin);
        posZ = Random.Range(-posMin, posMin);

        Vector3 newPosition = new Vector3(posX, transform.position.y, posZ);
        targetPos = newPosition;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,targetPos) < 10f)
        {
            getNewPosition();
        }

        Rotate();

    }

    void FixedUpdate()
    {
        Move();
    }

    void Rotate()
    {
        Vector3 tankDir = targetPos - transform.position;
        float step = speedRotate * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, tankDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Move()
    {
        Vector3 moveForward = transform.forward * speedMove;
        enemyTank.MovePosition(enemyTank.position + moveForward);
    }


}
