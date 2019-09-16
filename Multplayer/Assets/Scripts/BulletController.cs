using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            HP v = collision.gameObject.GetComponent<HP>();
            v.Damage(damage);
        }

        Destroy(gameObject);
    }
}
