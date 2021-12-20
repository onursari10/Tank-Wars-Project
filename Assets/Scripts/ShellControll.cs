using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControll : MonoBehaviour
{
    int Damage = 5;

    EnemyHealth EnH;

    private void Start()
    {
        EnH = GetComponent<EnemyHealth>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnH.TakeHit(Damage);
            Destroy(gameObject);
            Debug.Log("Enemy is hit");
        }
        else if (other.collider.tag == "ground")
        {
            Destroy(gameObject);
        }
    }

}
