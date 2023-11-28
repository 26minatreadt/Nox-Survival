using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
        if (other.tag == "Enemy")
        {
            DmgInfo dmgInfo = new DmgInfo(dmgValue, dmgColor, transform.parent.position);
            other.SendMessage("ApplyDmg", dmgInfo);
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
