using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class mala : MonoBehaviour
{//variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    //public Transform p;
    Vector3 initialposition;//posicion inicial

    public NavMeshAgent agente;
    void Start()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;
        agente.destination = player.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = player.transform.position;

        //Vector3 target = initialposition;



        //float dist = Vector3.Distance(player.transform.position, transform.position);
        //if (dist < vidionRadio) target = player.transform.position;

        //float fixedSpeed = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        //Debug.DrawLine(transform.position, target, Color.green);

    

}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
}
