using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Rigidbody shell;

    public Transform FireStart;

    private Transform mCanon;

    //int Damage = 5;

    //EnemyHealth EnH;

   
    void Start()
    {
        mCanon = FireStart.parent;
        //EnH = GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    public void shoot()
    {
        Rigidbody rbshell = Instantiate(shell, FireStart.position, mCanon.rotation);
        rbshell.velocity = 20.0f * mCanon.forward;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.collider.tag == "Enemy")
    //    {
    //        EnH.TakeHit(Damage);
    //        Destroy(gameObject);
    //        Debug.Log("Enemy is hit");
    //    }
    //    else if (other.collider.tag == "ground")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
