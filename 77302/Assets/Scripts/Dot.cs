using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Hero")
        {
            GameObject.Find("Audio_Eat").gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("AimTxt").gameObject.GetComponent<AimTxt>().AimCount--;
            GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

}
