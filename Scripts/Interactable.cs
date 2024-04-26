using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public MainUIController mainUIController; // Reference to the MainUICon script
    public GameObject Player;
    public GameObject StartPoint;
    public Text boxText;

    public ParticleSystem particleEffectA; // Reference to the particle effect
    public ParticleSystem particleEffectB; // Reference to the particle effec
    public AudioSource soundEffect; // Reference to the sound effect


    private void Start()
    {
        boxText.enabled = false;
    }


    public void Interact()
    {
        // Check if the tag of the GameObject is "stone"
        if (gameObject.name == "Stone")
        {
            // Call function A and B from MainUICon script
            mainUIController.pauseResume();
            mainUIController.ChnageDppu();
            mainUIController.ShowCursor();
            mainUIController.ShowInstrumentsPanel();
            if (soundEffect != null)
            {
                soundEffect.Play();
            }
            
            gameObject.SetActive(false);
            
        }
        // Check if the tag of the GameObject is "box"
        else if (gameObject.name == "BoxA")
        {
            boxText.enabled=true;
            boxText.text = "Stone dropped in BoxA";
            if (particleEffectA != null)
            {
                particleEffectA.Play();
            }
            

        }
        else if (gameObject.name == "BoxB")
        {
            boxText.enabled = true;
            boxText.text = "Stone dropped in BoxB";
            if (particleEffectB != null)
            {
                particleEffectB.Play();
            }
            

        }
        else if (gameObject.name == "BoxC")
        {
            Debug.Log("boxc");
           Player.transform.position = StartPoint.transform.position;

        }
    }
}
