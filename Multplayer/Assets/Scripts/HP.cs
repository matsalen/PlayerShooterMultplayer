using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HP : NetworkBehaviour
{
    [SerializeField] const int MaxHP = 100;
    [SyncVar (hook = "AtualizaHP")] [SerializeField] int HPAtual;
    [SerializeField] RectTransform BarraHP;
    [SerializeField] bool respawn;

    NetworkStartPosition[] pontosSpawn;

    private void Start()
    {
        HPAtual = MaxHP;
        if (isLocalPlayer) pontosSpawn = FindObjectsOfType<NetworkStartPosition>();
    }

    public void Damage(int quantidade)
    {
        if (!isServer) return;

        HPAtual -= quantidade;

        if (HPAtual <= 0)
        {
            if (respawn)
            {
                HPAtual = MaxHP;
                RpcRespawn();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void AtualizaHP(int vida)
    {
        BarraHP.sizeDelta = new Vector2(vida * 2, BarraHP.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        Vector3 posicaoSpawn = Vector3.zero;
        if (pontosSpawn != null && pontosSpawn.Length > 0)
        {
            posicaoSpawn = pontosSpawn[Random.Range(0, pontosSpawn.Length)].transform.position;
        }
        transform.position = posicaoSpawn;
    }
}
