using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int x = 1;
    public GameObject striker;
    public GameObject botStriker;
    public GameObject Board;
    public countdown timer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (x == 1)
        {
            striker.SetActive(true);
            botStriker.SetActive(false);      
            
            


        }
        else if (x == 2) 
        {
            striker.SetActive(false);
            botStriker.SetActive(true);
          
            
        }
        
        
    }
    
}
