using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawn : NetworkBehaviour
{
    [SerializeField] GameObject inimigoPrefab;
    [SerializeField] int numeroInimigos;

    public override void OnStartServer()
    {
        for (int i = 0; i < numeroInimigos; i++)
        {
            Vector3 posicaoSpawn = PontoAleatorio(8f);
            Quaternion rotacaoSpawn = Quaternion.Euler(0, Random.Range(0f, 180f), 0);

            GameObject inimigo = (GameObject)Instantiate(inimigoPrefab, posicaoSpawn, rotacaoSpawn);
            NetworkServer.Spawn(inimigo);
        }
    }

    private Vector3 PontoAleatorio(float raio)
    {
        Vector2 v = Random.insideUnitCircle * raio;
        return new Vector3(v.x, 0, v.y);
    }
}

