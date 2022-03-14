using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class uitext : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    void Start()
    {
       // text1.SetActive(false);
    }

   
   public void continuar()
    {
        text1.SetActive(false);

    }
    public void star1() {
        text2.SetActive(false);
    }
    public void star2()
    {
        text3.SetActive(false);
    }
    public void star3()
    {
        text4.SetActive(false);
    }
}
