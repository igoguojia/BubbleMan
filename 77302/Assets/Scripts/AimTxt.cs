using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AimTxt : MonoBehaviour
{
    public bool isBig = false;
    public GameObject Star;
    public int AimCount;
    private bool ableProtect=true;

    private void Start()
    {
        AimCount = 32;
    }
    void Update()
    {
        gameObject.GetComponent<Text>().text = ":" + AimCount.ToString();

        if((AimCount == 28 || AimCount == 18 || AimCount ==8) && !isBig)
        {
            int a = Random.Range(0, GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist.Count);
            Vector3 temp = GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[a].transform.position;
            temp.z = -6;
            //Instantiate(Star, GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[a].transform.position);
            GameObject obj = GameObject.Instantiate(Star, temp,Quaternion.identity) ;

            isBig = true;
        }
        if(AimCount==4&& ableProtect)
        {
            GameObject.Find("Maze").gameObject.GetComponent<Animator>().SetBool("isAlarm", false);

            foreach (Transform child in GameObject.Find("EnemyAll").gameObject.transform)
            {
                child.gameObject.GetComponent<GhostMoveAll>().State = 2;
                child.gameObject.GetComponent<GhostMoveAll>().speed = 0.1f;

            }
            ableProtect = false;
        }
        if (AimCount == 0)
        {
            Debug.Log("Win");
            SceneManager.LoadScene("03-Win");
        }
    }
}
