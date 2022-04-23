using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoVida : MonoBehaviour
{
    VidaPlayer playerVida;
    private SoundManager soundManager;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    public bool vivo = true;
    //public GameOverScreen GameOverScreen;


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
                GameOver();
                soundManager.SeleccionAudio(1, 0.5f);
            }
        }
    }
     public void GameOver()
    {
        // GameOverScreen.Setup(vida = 0);
        
            SceneManager.LoadScene(2);
            Debug.Log("Moristes");
        
    }

}
