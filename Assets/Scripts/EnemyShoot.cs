using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    bool enemyShooting = false;

    public int fireRate = 3;
    public float force = 100f;

    public Transform barrelEnd;
    public Rigidbody enemyShell;

    public Transform player;
    public Transform enemyTankHull;
    public float turrelSpeed = 1f;

    void Start()
    {
        //player = GameObject.Find("M4A3E2_1").transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyShooting == false)
        {
            enemyShooting = true;
            StartCoroutine("CoEnemyShootGun");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("CoEnemyShootGun");
            enemyShooting = false;
        }
    }

    void Update()
    {
        if (enemyShooting == true)
        {
            Quaternion playerRotation = Quaternion.LookRotation(player.position - transform.position);
            float angle = Quaternion.Angle(playerRotation, transform.rotation);
            if (Vector3.Dot(transform.TransformDirection(Vector3.right), (player.position - transform.position)) < 0f)
            {
                transform.RotateAround(enemyTankHull.position, enemyTankHull.up, angle * (-1f) * Time.deltaTime * turrelSpeed);
            }
            else
            {
                transform.RotateAround(enemyTankHull.position, enemyTankHull.up, angle * Time.deltaTime * turrelSpeed);
            }
        }
    }

    IEnumerator CoEnemyShootGun()
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot()
    {
        Rigidbody shell = Instantiate(enemyShell, barrelEnd.position, barrelEnd.rotation) ;

        shell.velocity = force * barrelEnd.forward;
    }


}
