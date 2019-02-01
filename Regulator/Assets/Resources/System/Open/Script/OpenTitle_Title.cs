using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OpenTitle_Title : MonoBehaviour
{
    public Image teamlogo, bg, titlelogo;
    public Text start;

    public FadeController faceController;

    public OpenTitleController otc;
    // Use this for initialization
    void Start()
    {
        faceController.OnToWhiteEnd += OnBlackBgToWhite;
        faceController.OnFadeOutEnd += OnTeamLogoFadeOutEnd;
        faceController.OnFadeInEnd += OnTeamLogoFadeInEnd;
        faceController.fadein(teamlogo,0,0.01f); // step1
    }

    void OnTeamLogoFadeInEnd()
    {
        faceController.fadeout(teamlogo,3,0.01f);//step2
        faceController.OnFadeInEnd -= OnTeamLogoFadeInEnd;
    }

    void OnTeamLogoFadeOutEnd()
    {
        faceController.toWhite(bg,0,0.01f);//step3
        faceController.OnFadeOutEnd -= OnTeamLogoFadeOutEnd;      
    }

    void OnBlackBgToWhite()
    {
        faceController.fadein(titlelogo,1,0.01f);
        Invoke("showText",3);
        faceController.clear();
        
    }

    void showText()
    {
        start.GetComponent<TW_Regular>().StartTypewriter();
        otc.step2();
    }

}