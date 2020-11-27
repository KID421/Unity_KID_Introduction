using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstroductionManager : MonoBehaviour
{
    [Header("KID LOGO")]
    public Animator aniLogo;
    [Header("KID 骨架物件")]
    public Animator aniKID;
    [Header("開始按鈕")]
    public Button btnStart;
    [Header("下一頁按鈕")]
    public Button btnNext;
    [Header("磚塊")]
    public GameObject objBrick;
    [Header("問號")]
    public GameObject objQuestion;
    [Header("金牌")]
    public GameObject objBeer;
    [Header("攝影機")]
    public Transform traCamera;

    private Vector2[] posKIDGo =
    {
        new Vector2(0, -6.2f),
        new Vector2(5, -6.2f)
    };
    private Vector2[] posKIDLogo =
    {
        new Vector2(-15, 1)
    };

    private void Awake()
    {
        btnStart.onClick.AddListener(() => StartCoroutine(PageOneFlow()));
        btnNext.onClick.AddListener(() => StartCoroutine(PageTwoFlow()));
    }

    private IEnumerator PageOneFlow()
    {
        btnStart.gameObject.SetActive(false);
        aniLogo.SetTrigger("開始");

        yield return new WaitForSeconds(1);
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[0]) > 0.3f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(0.3f);
        aniKID.SetTrigger("招手");

        yield return new WaitForSeconds(1.5f);
        btnNext.gameObject.SetActive(true);
    }

    private IEnumerator PageTwoFlow()
    {
        btnNext.gameObject.SetActive(false);

        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniLogo.transform.position , posKIDLogo[0]) > 0.3f)
        {
            aniLogo.transform.Translate(-7 * Time.deltaTime, 0, 0);
            yield return null;
        }

        aniKID.SetBool("跑步開關", false);

        yield return new WaitForSeconds(0.5f);

        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(0.5f);
        objBrick.SetActive(true);

        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(0.5f);
        objQuestion.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[1]) > 0.1f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            traCamera.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(0.3f);
        aniKID.SetTrigger("跳躍");

        yield return new WaitForSeconds(0.5f);
        objBeer.SetActive(true);

    }
}
