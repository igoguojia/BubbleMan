using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPosList : MonoBehaviour
{
    // Start is called before the first frame update
   // public List<Vector3> dotlist = new List<Vector3>();
    public List<GameObject> dotlist = new List<GameObject>();
    void Start()
    {
        //foreach (Transform child in this.transform)

        //{
        //    dotlist.Add(child.transform.position);

        //}
        foreach (Transform child in this.transform)

        {
            dotlist.Add(child.gameObject);
        }

    }

}
