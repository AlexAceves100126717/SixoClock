using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stalker : MonoBehaviour
{
    public NavMeshAgent enemigo;
    public Transform Jugador;
    public float SeguirT = 2f;
    public float DescansarT = 5f;
    public int dificultad = 1;


    [SerializeField]
    private Animator AlienAnimator;
    private string currentAnimation;


    const string Alien_Idle = "Alien_Idle";
    const string Alien_Walk = "Alien_Walk";
    const string Alien_Hit = "Alien_Hit";



    // Start is called before the first frame update
    void Start()
    {

        enemigo = GetComponent<NavMeshAgent>();
        ChangeAnimationState(Alien_Idle);
        //AlienAnimator.SetTrigger("Alien_Idle");
        //AlienAnimator.SetTrigger("Alien_Hit");

    }

    // Update is called once per frame
    void Update()
    {
        enemigo.SetDestination(Jugador.position);
        StartCoroutine(Stalkeo());
    }

    IEnumerator Stalkeo()
    {

        yield return StartCoroutine(Corrutina.EsperarSegundosReales(10f));
        enemigo.SetDestination(Jugador.position);
        //AlienAnimator.SetTrigger("Walk");



        while (gameObject)
        {
            yield return StartCoroutine(Corrutina.EsperarSegundosReales(SeguirT * dificultad));
            enemigo.Stop(true);
            //AlienAnimator.SetTrigger("Alien_Idle");




            yield return StartCoroutine(Corrutina.EsperarSegundosReales(DescansarT / dificultad));
            enemigo.Resume();
            //AlienAnimator.SetTrigger("Walk");
            ChangeAnimationState(Alien_Walk);


            enemigo.SetDestination(Jugador.position);

        }

    }

    private void OnTriggerEnter(Collider objetivo)
    {
        if (objetivo.tag == "Player")
        {
            Debug.Log("Cocando");
            // AlienAnimator.SetTrigger("Alien_Hit");
            ChangeAnimationState(Alien_Hit);


        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;

        AlienAnimator.Play(newState);

        currentAnimation = newState;
    }
}
