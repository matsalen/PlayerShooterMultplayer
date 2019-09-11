using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] const int MaxHP = 100;
    [SerializeField] int AtualHP;

    private void Start()
    {
        AtualHP = MaxHP;
    }

    public void Damage(int quantidade)
    {
        AtualHP -= quantidade;
        if (AtualHP <= 0)
        {
            AtualHP = 0;
            Debug.Log("Dead = true");
        }
    }
}
