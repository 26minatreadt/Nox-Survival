using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class DmgInfo 
{
    public int dmgValue; //Damage value
    public Color textColor; //Color of the damage text
    public Vector3 dmgDir; //Position where the damage comes from 

    public DmgInfo(int dmgv, Color tcolor, Vector3 dmgd)
    {
        dmgValue = dmgv;
        textColor = tcolor;
        dmgDir = dmgd;
    }
}
