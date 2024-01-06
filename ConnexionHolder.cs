using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ConnexionHolder : MonoBehaviour
{
    public bool dontDestroy;
    //public string GameLife;
    //public GameObject healthBar;
    //public GameObject fire;
    //public static TMP_Text vieActuelle;
    //public static GameObject vie;
    public float Score = 100;
    // Start is called before the first frame update
    public void Start()
    {
        //Debug.Log("valeur name au start : "+connexionHolder.toBeMaintaned);
        if(dontDestroy)
        {
        DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
   public void Update()
   {
    Score = GameObject.Find("HealthBar").GetComponent<Scrollbar>().size * 100 ;
    //vieActuelle.GetComponent<TextMesh>().text = "You are alive with"; //+ healthBar.transform.Find("Mask").Find("Sprite").GetComponent<Scrollbar>().size * 100 + "% of health";
     //if (fire.GetComponent<Fire>().currentIntensity <= 0)
      //  {
       // vie.GetComponent<Text>().text = "You are alive with" + healthBar.GetComponent<Scrollbar>().size * 100 + "% of health";
        //AllerNiveau();
      //  Debug.Log("Scene change");
     //   }
    }

   // public void AllerNiveau()
    //{
       // SceneManager.LoadScene(GameLife);
   // }
}
