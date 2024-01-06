using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthBar : MonoBehaviour
{
	public GameObject healthBar;
    // public GameObject fire;
	public string GameOver;
    //public string GameLife;
    
    //public TMP_Text vie;

	public Color goodColor;
	public Color middleColor;
	public Color badColor;
	public TMP_Text Txt;
    //public float TotalHealth;

    //public float santeMaximale = 1.0f; // Santé maximale du joueur
    //public float dureeExpositionMax = 60.0f; // Durée maximale d'exposition au danger en secondes
    public float tauxExposition;
    //public float santeActuelle;  // Santé actuelle du joueur
    //public float dureeExposition; // Durée d'exposition au danger en cours


    void Start() 
    { 
        //Txt=healthBar.transform.Find("Mask").Find("Sprite").Find("Text").GetComponent<Text>();
		Txt.text= healthBar.GetComponent<Scrollbar>().size * 100 + "%";
		
		//santeActuelle = santeMaximale; // Initialisation de la santé actuelle
        //dureeExposition = 0.0f; // Initialisation de la durée d'exposition
        //SetHealth(tauxExposition);
        SetColor();
    }

	// Start is called before the first frame update


    // Update is called once per frame
    void Update() 
     //{
      //do
       {
        //dureeExposition += Time.deltaTime;
        SetHealth(tauxExposition);
        
       } //while (santeActuelle >= 0);
     //} 
    

    public void SetHealth(float value)
    {
        // Simulez l'exposition au danger en augmentant la durée d'exposition
        
        //while duree<expositiib
        
       if (healthBar.GetComponent<Scrollbar>().size <= 0)
        {

         AllerAuNiveau();
  
         // La durée d'exposition maximale est atteinte, vous pouvez gérer cela ici
        Debug.Log("Vous êtes mort");
        }

        //if (fire.GetComponent<Fire>().currentIntensity <= 0)
        //{
        //vie.text = "You are alive with" + healthBar.GetComponent<Scrollbar>().size * 100 + "% of health";
        //AllerNiveau();
        //Debug.Log("Scene change");
        //}

        // Calculez la proportion de santé en fonction de la durée d'exposition
        //float proportionSante = 1.0f - (dureeExposition / dureeExpositionMax);
       // value = proportionSante * santeMaximale;

        healthBar.GetComponent<Scrollbar>().size -= value;

        float santeActuelle = healthBar.GetComponent<Scrollbar>().size;
		Txt.text=santeActuelle* 100 + "%";
		SetColor(santeActuelle);
        //TotalHealth = santeActuelle;
    }

   
	public void AllerAuNiveau()

    {
        SceneManager.LoadScene(GameOver);
    }

    //public void AllerNiveau()

   // {
        //SceneManager.LoadScene(GameLife);
   // }

	void SetColor(float value = 1)
	{
         if (value >= 0.5f) 
		 {
            healthBar.transform.Find("Mask").Find("Sprite").GetComponent<Image>().color = goodColor;
		 }

		 else if (value >=0.25f && value < 0.5f) 
		 {
			healthBar.transform.Find("Mask").Find("Sprite").GetComponent<Image>().color = middleColor;
		 }
		 
		 else 
		 {
			healthBar.transform.Find("Mask").Find("Sprite").GetComponent<Image>().color = badColor;
		 }
         
	}

}
