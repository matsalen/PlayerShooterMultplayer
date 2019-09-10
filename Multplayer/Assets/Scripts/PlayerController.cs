using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidadeRotacao;
    [SerializeField] float velocidade;

    float x, y;
    

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadeRotacao;
        y = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, y);
    }
}
