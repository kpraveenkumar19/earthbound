using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gamemanager1 : MonoBehaviour
{
   
    ladyUI l;
    manUI  m;
    shopkeeperUI s;

    [SerializeField] float delay1 = 4f;
    
    void Awake()
    {
        
        s = FindObjectOfType<shopkeeperUI>();
        l = FindObjectOfType<ladyUI>();
        m = FindObjectOfType<manUI>();

    }

   
        void OnTriggerStay2D(Collider2D other) {
    
    if(other.tag=="Player"){
          
    
         s.gameObject.SetActive(true);
          m.gameObject.SetActive(false);
          l.gameObject.SetActive(false);
          
         
         

         
       
        
    
    }
    


       }
      
    }
   
    
    
   

