using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public float force;//力
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        isPause = GameObject.Find("pauseBtn").gameObject.GetComponent<PausePanel>().isPause;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.localEulerAngles = new Vector3(0, 0, 270);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.localEulerAngles = new Vector3(0, 0, 90);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -1, 0) * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * force * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isPause)
        {
            GameObject.Find("pauseBtn").GetComponent<PausePanel>().PausePanelOpen();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isPause)
        {
            GameObject.Find("ResumeBtn").GetComponent<PausePanel>().Resume();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //if (GameObject.Find("Enemy1").gameObject.GetComponent<GhostMoveAll>().State != 3)
            //{
            //    Debug.Log("Game Over");
            //    SceneManager.LoadScene("04-Lose");
            //}
            if (collision.gameObject.GetComponent<GhostMoveAll>().State == 3
                ||
                collision.gameObject.GetComponent<GhostMoveAll>().State == 1)
            {
                collision.gameObject.GetComponent<GhostMoveAll>().isDie = true;
            }
            else
            {
                GameObject.Find("Audio_Die").gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("Game Over");
                SceneManager.LoadScene("04-Lose");
            }

        }
    }
  
}
