using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoVida : MonoBehaviour
{
    VidaPlayer playerVida;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime>damageTime)
            {
                playerVida.vida += cantidad;
                currentDamageTime=0.0f;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
   {
       if (collision.tag == "Player")
       {
           Destroy(gameObject);
           Debug.Log("Aumentaste Vida");
       }
   }
}
