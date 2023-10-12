using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerCont;

    public Weapon weapon;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerCont = GetComponentInParent<PlayerController>();
    }

    public void EnableMove()
    {
        playerCont.EnableMove(true);
    }
    public void DisableMove()
    {
        playerCont.EnableMove(false);
    }

    public void EnableWeaponColl()
    {
        weapon.EnableColliders();
    }
    public void DisableWeaponColl()
    {
        weapon.DisableColliders();
    }
}
