using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class e3 : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointsIndex;
    private float dista;
    /// <summary>
    /// ///////////
    /// </summary>
      //variable para la vision velocidad
   // public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    Vector3 initialposition;//posicion inicial
 
   
   
   
    public bool gameActivo = true;
   // private VidaPlayer vida;
   // private Vida3 vidaGordo;
    void Start()
    {
        waypointsIndex = 0;
        transform.LookAt(waypoints[waypointsIndex].position);
        //
        player = GameObject.FindGameObjectWithTag("Player");

        initialposition = transform.position;


       

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
    void Update()
    {
        Vector3 target = initialposition;


      
           // float dist = Vector3.Distance(player.transform.position, transform.position);
           
                dista = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);
                if (dista < 1f)
                {

                    increseIndex();
                }
                Patrol();
            
         

        
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void increseIndex()
    {
        waypointsIndex++;
        if (waypointsIndex >= waypoints.Length)
        {
            waypointsIndex = 0;
        }
        transform.LookAt(waypoints[waypointsIndex].position);
    }

   
}
