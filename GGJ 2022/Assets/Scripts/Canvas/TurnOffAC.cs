using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffAC : MonoBehaviour
{
    [Header("默认")]
    [SerializeField] private float localTotal;
    [SerializeField] private float second;
    [SerializeField] private bool isStart;

    [Header("需要预输入")]
    [SerializeField] private float totalTime;
    [SerializeField] private Text tempText;
    [Header("观察")]
    [SerializeField] private bool isOff;
    [SerializeField] private float disableTime;


    private void OnEnable()
    {
        if(disableTime - GameManager.Instance.worldData.worldTime >= 20)
        {
            isOff = false;
        }

        if (!isOff)
        {
            localTotal = totalTime;
            isStart = true;
            second = 0;
            SimpleDialogue.Instance.dialogue.SetActive(true);

            SimpleDialogue.Instance.dialogueText.text = "按住上箭头加速";

            Invoke("TurnOffPage", 2f);
        }

    }

    private void OnDisable()
    {
        if(isOff)
        {
            disableTime = GameManager.Instance.worldData.worldTime;
        }
    }

    private void Update()
    {


        if (isOff)
        {
            StartCoroutine(OffAlready());
        }

        if (isStart && !isOff)
        {
            SetTemp();
            PressUp();
        }

        //中断
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopTrick();
        }
    }

    public void PressUp()
    {
        second += Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            second += Time.deltaTime / 1.2f;
        }

        if (second >= 1)
        {
            second = 0;
            localTotal -= 1;
        }

        if (localTotal == 0)
        {
            EventHandler.CallEveryFeelHot();
            StartCoroutine(StartTalk());
            isStart = false;

            isOff = true;
            FindObjectOfType<addWarning>().add30();
            gameObject.SetActive(false);
        }

    }

    IEnumerator StartTalk()
    {
        //TODO 字幕 你成功关掉了空调
        SimpleDialogue.Instance.StartDialogue("你成功关闭了空调！", 2f);
        //FindObjectOfType<addWarning>().Add20();
        yield return new WaitForSeconds(3f);
        EventHandler.CallEveryFeelHot();
    }

    IEnumerator OffAlready()
    {
        //TODO 字幕 你已经把空调关掉了
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    public void StopTrick()
    {
        isStart = false;
        gameObject.SetActive(false);
    }

    public void SetTemp()
    {
        //假设最高为32°
        tempText.text = (23f + (13f / totalTime) * (totalTime - localTotal)).ToString("00");
    }

    public void TurnOffPage()
    {
        SimpleDialogue.Instance.dialogue.SetActive(false);
    }
}
