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
    [Header("磚塊群")]
    public GameObject[] bricks;
    [Header("金幣群")]
    public GameObject[] coins;

    private Vector2[] posKIDGo =
    {
        new Vector2(0, -6.2f),
        new Vector2(5, -6.2f),
        new Vector2(16, -6.2f),
        new Vector2(20, -2.7f),
        new Vector2(26, -2.7f),
        new Vector2(50, 0),
    };
    private Vector2[] posKIDLogo =
    {
        new Vector2(-15, 1)
    };

    private void Awake()
    {
        Time.timeScale = 1;
        btnStart.onClick.AddListener(() => StartCoroutine(PageOneFlow()));
        btnNext.onClick.AddListener(() => StartCoroutine(PageTwoFlow()));
    }

    private IEnumerator PageOneFlow()
    { 
        // 隱藏按鈕並顯示 LOGO
        btnStart.gameObject.SetActive(false);
        aniLogo.SetTrigger("開始");

        // 跑向畫面中間
        yield return new WaitForSeconds(1);
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[0]) > 0.3f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        // 停止跑步並招手
        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(0.3f);
        aniKID.SetTrigger("招手");

        // 顯示下一頁按鈕
        yield return new WaitForSeconds(1.5f);
        btnNext.gameObject.SetActive(true);
    }

    private IEnumerator PageTwoFlow()
    {
        // 隱藏按鈕並開始跑向右邊
        btnNext.gameObject.SetActive(false);
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniLogo.transform.position , posKIDLogo[0]) > 0.3f)
        {
            aniLogo.transform.Translate(-7 * Time.deltaTime, 0, 0);
            yield return null;
        }

        // 停止跑步並揮手
        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(1f);
        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(1f);
        objBrick.SetActive(true);
        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(1f);
        objQuestion.SetActive(true);

        // 停留後跑向問號方塊
        yield return new WaitForSeconds(2f);
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[1]) > 0.1f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            traCamera.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        // 跳躍並顯示金牌
        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(0.3f);
        aniKID.SetTrigger("跳躍");
        yield return new WaitForSeconds(0.5f);
        objBeer.SetActive(true);
        
        // 下一頁按鈕事件改為第三頁並顯示按鈕
        btnNext.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(2);
        btnNext.onClick.AddListener(() => StartCoroutine(PageThreeFlow()));
        btnNext.gameObject.SetActive(true);
    }

    private IEnumerator PageThreeFlow()
    {
        // 隱藏按鈕並開始跑向右邊
        btnNext.gameObject.SetActive(false);
        aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[2]) > 0.1f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            traCamera.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(1);
        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.3f);
        aniKID.SetTrigger("跳躍");

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[3]) > 0.1f)
        {
            aniKID.transform.position = Vector2.Lerp(aniKID.transform.position, posKIDGo[3], Time.deltaTime * 3);
            traCamera.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        aniKID.SetBool("跑步開關", true);
        while (Vector2.Distance(aniKID.transform.position, posKIDGo[4]) > 0.1f)
        {
            aniKID.transform.Translate(5 * Time.deltaTime, 0, 0);
            traCamera.Translate(5 * Time.deltaTime, 0, 0);
            yield return null;
        }

        aniKID.SetBool("跑步開關", false);
        yield return new WaitForSeconds(1);
        aniKID.SetTrigger("揮手");
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

        // 下一頁按鈕事件改為第三頁並顯示按鈕
        btnNext.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(2);
        btnNext.onClick.AddListener(() => StartCoroutine(PageFourFlow()));
        btnNext.gameObject.SetActive(true);
    }

    private IEnumerator PageFourFlow()
    {
        // 隱藏按鈕並開始跑向右邊
        btnNext.gameObject.SetActive(false);
        //aniKID.SetBool("跑步開關", true);

        while (Vector2.Distance(aniKID.transform.position, posKIDGo[5]) > 0.1f)
        {
            aniKID.transform.position = Vector2.Lerp(aniKID.transform.position, posKIDGo[5], Time.deltaTime * 2);
            Vector3 posKID = aniKID.transform.position;
            posKID.y = traCamera.position.y;
            posKID.z = -10;
            traCamera.position = Vector3.Lerp(traCamera.position, posKID, Time.deltaTime * 2);
            yield return null;
        }
    }
}
