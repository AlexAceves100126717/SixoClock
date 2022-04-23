using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVida : MonoBehaviour
{
    VidaPlayer playerVida;
    private SoundManager soundManager;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();

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
                soundManager.SeleccionAudio(1, 0.5f);
            }
        }
    }

}
