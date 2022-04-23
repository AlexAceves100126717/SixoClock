
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutina : MonoBehaviour
{
    public static IEnumerator EsperarSegundosReales(float tiempo)
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (start + tiempo))
        {
            yield return null;

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}