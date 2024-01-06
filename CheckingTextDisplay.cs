using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class CheckingTextDisplay : MonoBehaviour
{
    private ARSessionOrigin arSessionOrigin;
  
    public GameObject checkText; /**< Le GameObject contenant le texte */
    public GameObject pullText;
   [SerializeField] private Transform raycastOrigin = null;
   
    public GameObject loinDistance;
    public GameObject procheDistance;
    public GameObject bonDistance;

    public GameObject gameObjectCible; // Remplacez par votre GameObject cible
    public float distanceMinimale = 10f; // Définissez la distance minimale en mètres : la plage distancielle où on doit être présent pour pas que le feu projette sur nous
    public float distanceMaximale = 15f; // Définissez la distance maximale en mètres
    

      /**Activation texte**/ 

    private bool IsRaycastingSomething(out RaycastHit hit) => Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 100f);

    private bool IsRaycastingFire(out Fire fire) 
    {
        fire = null;

        return IsRaycastingSomething(out RaycastHit hit) && hit.collider.TryGetComponent(out fire);
    }
 
 
 void start ()
{
  pullText.SetActive(false);
}

    private void Update()

    {
        if (IsRaycastingFire(out Fire fire))
        {

        // Obtenez la position de la caméra par rapport au GameObject cible
        Vector3 positionCamera = raycastOrigin.transform.position;
        Vector3 positionCible = gameObjectCible.transform.position;
        float distance = Vector3.Distance(positionCamera, positionCible);

         Debug.Log("Distance entre la caméra AR et l'objet : " + distance + "m");

        // Vérifiez si la distance est inférieur à la distance maximale et que l'objet déclencheur est toujours actif
        if (distance < distanceMinimale)
        {
    
         procheDistance.SetActive(true);
         loinDistance.SetActive(false);
         bonDistance.SetActive(false);

        }
        if (distance > distanceMaximale)
        {
          loinDistance.SetActive(true);
          bonDistance.SetActive(false);
          procheDistance.SetActive(false);
        }
        if (distance >= distanceMinimale && distance <= distanceMaximale)
        {
          
          bonDistance.SetActive(true);
          procheDistance.SetActive(false);
          loinDistance.SetActive(false);
          

          Invoke("Temporisation", 2f);
         
         Invoke("Temporisation2", 2f);
        

        }

           
           
        } 

     }

     void Temporisation()
     {
       checkText.SetActive(false);
       bonDistance.SetActive(false);
      

     }
void Temporisation2()
{
 pullText.SetActive(true);
}
     
}








