using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] public float currentIntensity = 1.0f;  
    public float GetIntensity() => currentIntensity;
    public string GameLife;
    
  
    private float[] startIntensities = new float[0];  //L'intensité des particules du feu, fumées...
    float nextRegenTime = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;
    
    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    private bool isLit = true;

    private void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];

        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
    }

   

    private void Update()
    {
        if (isLit && currentIntensity < 1.0f)         
            Regenerate();          
    }

    private void Regenerate() 
    {
        if (Time.time < nextRegenTime)
            return;

        currentIntensity += regenRate * Time.deltaTime;
        ChangeIntensity();
    }

    public bool TryExtinguish(float amount) 
    {
        nextRegenTime = Time.time + regenDelay;

        currentIntensity -= amount;

        ChangeIntensity();

        if (currentIntensity <= 0) 
        {
            Die();
            GetComponent<AudioSource>().Stop();
            return true;
           
        }

        return false; //fire is still lit
    }

 public void Die() 
    {
        isLit = false;
        enabled = false;
        
        AllerNiveau();
        //Debug.Log("Scene change");
    }

    public void AllerNiveau()

    {
        SceneManager.LoadScene(GameLife);
    }

    private void ChangeIntensity()  //change l'intensité d'émission du feu et fumées 
    {
        for (int i = 0; i < fireParticleSystems.Length; i++) //pour tous les particules présentes dans le feu
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
