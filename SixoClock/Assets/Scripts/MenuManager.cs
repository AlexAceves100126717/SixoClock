using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  
        // Start is called before the first frame update
        public void BotonStart()
        {
            SceneManager.LoadScene(1);
        }

    public void BotonCreditos()
    {
        SceneManager.LoadScene(1);
    }

    public void BotonMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void BotonQuit()
        {
            Debug.Log("Quitamos la Aplicacion");
            Application.Quit();
        }

}


