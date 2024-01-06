using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfficheScore : MonoBehaviour
{
    public TMP_Text TxtScore;
    private GameObject Vie;
    
    // Start is called before the first frame update
 

    // Update is called once per frame
   

    void Start()
    {
       Vie=GameObject.Find("VieActuelle"); 
       //TxtScore.text = " You are alive with " + Vie.GetComponent<ConnexionHolder>().Score + " % of health";
    }

    void Update()
    {
        
        TxtScore.text = " You are alive with " + Vie.GetComponent<ConnexionHolder>().Score + " % of health";
        
    }
    
 
}
