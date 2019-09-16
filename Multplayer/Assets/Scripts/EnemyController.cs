using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float velocidade;
    PlayerController player;

    private void Start()
    {
        player = (PlayerController)FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        InvokeRepeating("Move", 2f, 1f);
    }

    private void Move()
    {
        if (player == null)
        {
            player = (PlayerController)FindObjectOfType<PlayerController>();

        }
        transform.LookAt(player.gameObject.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * velocidade;
    }
}
