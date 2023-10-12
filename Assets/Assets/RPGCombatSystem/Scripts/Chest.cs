using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isPlayerNear = false;
    private bool isOpen = false;

    void Update()
    {
        if (!isOpen && isPlayerNear)
        {
            if (Input.GetButtonDown("Interact"))
            {
                OpenChest();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
        }
    }

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
        {
            isPlayerNear = false;
        }
    }

    private void OpenChest()
    {
        isOpen = true;
        GetComponent<Animator>().Play("Open");
        GetComponent<AudioSource>().Play();
    }
}
