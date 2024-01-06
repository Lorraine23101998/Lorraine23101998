using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class left : MonoBehaviour
{
    public float deplacementX = 1f; // La distance de déplacement sur l'axe X
 
    public void ButoonPressed()
    {

            // Déplace l'objet sur l'axe X
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + deplacementX;
            transform.position = newPosition;

    }
    void Start()
    {

    }
    void Update()
    {

    }
}




