using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public Transform damageTextPos;

    private bool isInvincible = false;
    private Animator anim;
    private AudioSource audioS;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    public void ApplyDmg(DmgInfo dmgInfo)
    {
        if (!isInvincible)
        {
            anim.Play("Hitted");
            audioS.Play();
            GameObject dmgText = Instantiate(damageTextPrefab, damageTextPos.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp(dmgInfo.dmgValue + Random.Range(-10, 10), dmgInfo.textColor);
            StartCoroutine("MakeInvincible");
        }
    }

    IEnumerator MakeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(.5f);
        isInvincible = false;
    }
}
