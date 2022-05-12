using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public float Health = 100;
    public Image barraVida;
    float elapsed = 0f;

    void Awake()
    {
        barraVida.fillAmount = 1f;
    }

    void Start()
    {
        
        StartCoroutine(restarHealth());
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, 100);
        //barraVida.fillAmount = Health / 100;
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                UpdateHealth();
            /*if (Health==0)
            {
                GameOver();
            }*/

        }
    }

    IEnumerator restarHealth()
    {
        while (true)
        {
            if (Health > 1)
            {
                Health -= 1f;
                yield return new WaitForSeconds(1f);
                UpdateHealth();
            }            
        }
    }
    void UpdateHealth()
    {
        barraVida.fillAmount = Health / 100;
    }

    /*public void GameOver()
    {
        SceneManager.LoadScene(2);
    }*/
    /*IEnumerator restarHealth()
    {
        while (true)
        { // loops forever...
            if (Health > 1)
            { // if health < 100...
                Health -= 1; // increase health and wait the specified time
                //barraVida.fillAmount = Health / 100;
                yield return new WaitForSeconds(1f);
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
        }
    }*/
}