using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventsEn : MonoBehaviour
{
    //private Animator anim;
    private SoundManager soundMan;

    public WeaponEnemy weapon; 

    public bool isAttacking = false; //To prevent colliders from being activated if there is delay in the animation

    void Start()
    {
        //anim = GetComponent<Animator>();
        soundMan = GetComponentInParent<SoundManager>();
    }

    public void EnableMove()
    {
        //playerCont.EnableMove(true);
    }
    public void DisableMove()
    {
        soundMan.PlaySound("Attack");
        //playerCont.EnableMove(false);
    }

    public void EnableWeaponColl()
    {
        if(isAttacking)
            weapon.EnableColliders();
    }
    public void DisableWeaponColl()
    {
        weapon.DisableColliders();
    }

    public void PlaySound(string soundName)
    {
        soundMan.PlaySound(soundName);
    }
}
