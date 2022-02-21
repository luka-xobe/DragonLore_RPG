using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    private GameObject triggeringNPC;
    private bool triggering;

    public GameObject interactText;


    void Update()
    {
        if (triggering)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Activated");
            }
           
        }
        else
        {
            interactText.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            triggering = false;
            triggeringNPC = null;
        }



    }

}
