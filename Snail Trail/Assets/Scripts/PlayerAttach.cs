using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;
    public GameObject player;
    public GameObject otherplat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
            anim = GetComponent<Animator>();
            anim.enabled = true;
            if (otherplat != null)
            {
                anim2 = otherplat.GetComponent<Animator>();
                anim2.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
