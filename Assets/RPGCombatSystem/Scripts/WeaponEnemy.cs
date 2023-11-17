using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public int dmgValue = 132; //Damage of the weapon
    public Color dmgColor = Color.cyan; //Color of the text with the damage value

    private BoxCollider coll; //Collider of the weapon

    void Awake()
    {
        coll = GetComponent<BoxCollider>();
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ApplyDMG(other.transform.position - transform.position, 250f);
        }
	}

    public void EnableColliders() //Called from the AnimatorEvent script
    {
        coll.enabled = true;
    }

    public void DisableColliders() //Called from the AnimatorEvent script
    {
        coll.enabled = false;
    }
}
