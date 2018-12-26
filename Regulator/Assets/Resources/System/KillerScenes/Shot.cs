using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public GameObject[] pc = new GameObject[8];
    public Camera camera;
    public GameObject Lose,background;
    public void start()
    {
        for (int i = 0; i < 8; i++)
        {
            if (pc[i].GetComponent<PolygonCollider2D>()
                .OverlapPoint(new Vector2(camera.transform.position.x, camera.transform.position.y)))
                pc[i].GetComponent<Animator>().SetTrigger("die");
            Invoke("Scream",1f);
        }

        if (pc[7].GetComponent<PolygonCollider2D>()
            .OverlapPoint(new Vector2(camera.transform.position.x, camera.transform.position.y)))
        {
           Invoke("win",3f);
            Invoke("Scream",1f);
        }
        else
        {
            Invoke("lose",3f);
            Invoke("Scream",1f);
        }
    }

    void lose()
    {
        SceneManager.LoadScene("Lose");
    }

    void win()
    {
  

            SceneManager.LoadScene("Soulend");
    }

    void Scream()
    {
        background.GetComponent<AudioSource>().Play();
    }
}