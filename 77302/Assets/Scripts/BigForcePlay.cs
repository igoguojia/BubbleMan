using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigForcePlay : MonoBehaviour
{


    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = GameObject.Find("EnemyAll").gameObject;
        //GameObject aimtxt = GameObject.Find("AimTxt").gameObject;
        if (collision.name == "Hero")
        {
            foreach (Transform child in enemy.transform)
            {
                child.gameObject.GetComponent<GhostMoveAll>().State = 3;
            }
            GameObject.Find("Audio_Alarm").gameObject.GetComponent<AudioSource>().Play();
            //enemy.gameObject.GetComponent<GhostMoveAll>().State = 3;
            //e2.gameObject.GetComponent<GhostMoveAll>().State = 3;
            //e3.gameObject.GetComponent<GhostMoveAll>().State = 3;
            //e4.gameObject.GetComponent<GhostMoveAll>().State = 3;
            GameObject.Find("AimTxt").gameObject.GetComponent<AimTxt>().isBig = false;
            GameObject.Find("Maze").gameObject.GetComponent<Animator>().SetBool("isAlarm", true);
            Destroy(this.gameObject);
        }
    }
}
