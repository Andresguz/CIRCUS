using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class GameManager : MonoBehaviour
{
   public Player player;
    public GameObject text4;
    public GameObject star;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (player.contStar == 2)
        {
            text4.SetActive(true);
            star.SetActive(true);
        }
    }
}
