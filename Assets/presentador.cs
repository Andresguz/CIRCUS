using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentador : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    void Start()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("incio"))
        {
            t1.SetActive(true);
         
        }
        if (other.gameObject.CompareTag("text1"))
        {
            t2.SetActive(true);
        }
        if (other.gameObject.CompareTag("text2"))
        {
            t3.SetActive(true);
        }
    }
}
