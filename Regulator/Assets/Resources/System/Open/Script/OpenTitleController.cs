using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenTitleController : MonoBehaviour
{
    public FadeController fc;

    public Image BlackBG;

    // Use this for initialization
    void Start()
    {
        // step 1
        // is Title
        // when title end execute steop2  
    }

    public void step2()
    {
        InvokeRepeating("check", 2, 0.1f);
    }

    void check()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fc.fadein(BlackBG, 0, 0.01f);
            Invoke("nextStage", 3);
            CancelInvoke("check");
        }
    }

    void nextStage()
    {
        SceneManager.LoadScene("KillerScenes");
    }
}