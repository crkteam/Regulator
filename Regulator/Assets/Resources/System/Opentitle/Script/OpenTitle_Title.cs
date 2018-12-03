using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class OpenTitle_Title : MonoBehaviour
{
    public Image teamlogo, bg, titlelogo;
    public Text start;

    public FadeController fc;

    public OpenTitleController otc;
    // Use this for initialization
    void Start()
    {
        fc.OnToWhiteEnd += OnBlackBgToWhite;
        fc.OnFadeOutEnd += OnTeamLogoFadeOutEnd;
        fc.OnFadeInEnd += OnTeamLogoFadeInEnd;
        fc.fadein(teamlogo,0,0.01f); // step1
    }

    void OnTeamLogoFadeInEnd()
    {
        fc.fadeout(teamlogo,3,0.01f);//step2
        fc.OnFadeInEnd -= OnTeamLogoFadeInEnd;
    }

    void OnTeamLogoFadeOutEnd()
    {
        fc.toWhite(bg,0,0.01f);//step3
        fc.OnFadeOutEnd -= OnTeamLogoFadeOutEnd;      
    }

    void OnBlackBgToWhite()
    {
        fc.fadein(titlelogo,1,0.01f);
        Invoke("showText",3);
        fc.clear();
        
    }

    void showText()
    {
        start.GetComponent<TW_Regular>().StartTypewriter();
        otc.step2();
    }

}