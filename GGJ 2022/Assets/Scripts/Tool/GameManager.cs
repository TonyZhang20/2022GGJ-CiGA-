using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : SingleTon<GameManager>
{
    public Image warningBar;
    public WorldData_SO worldData_SO;
    private float second = 0;
    public GameObject player;
    public PlayerData_SO playerData_SO;
    public WorldData_SO worldData;

    [Header("道具检查")]
    public bool hasBrand;
    public bool hasTool;
    public float mTime;
    public Text showTime;
    public Text showScore;
    public bool hasSer;

    private bool isDecreasing;
    protected override void Awake()
    {
        base.Awake();
        worldData = Instantiate(worldData_SO);
    }

    public void RegisterPlayer(PlayerData_SO playerData_SO)
    {
        this.playerData_SO = playerData_SO;
    }

    private void Update()
    {
        UpdateWarning();
        TimeCount();
        if(worldData.warning > 0f && isDecreasing == false)
        {
            StartCoroutine(DecreaseWarning());
            isDecreasing = true;
        }
        mTime += Time.deltaTime;

        showTime.text = "剩余时间: " + worldData.worldTime.ToString();
        showScore.text = "得分: " + worldData.score.ToString();

    }
    /// <summary>
    /// 1秒钟 = 8分钟
    /// </summary>
    public void TimeCount()
    {
        second += Time.deltaTime;
        if (second >= 1)
        {
            worldData.worldTime -= 1;
            second = 0;
        }

        if(worldData.worldTime <= 0)
        {
            PlayerPrefs.SetFloat("Score", worldData.score);
            PlayerPrefs.Save();
            
            ChangeScene.Instance.GoToScoreScene();
        }
    }

    public void ChangeHasBrand()
    {
        hasBrand = !hasBrand;
    }

    public void ChangeHasTool()
    {
        hasTool = !hasTool;
    }

    public void UpdateWarning()
    {
        if(worldData.warning >= 100f)
        {
            ChangeScene.Instance.GoToEndScene();
        }
        warningBar.fillAmount = worldData.warning / 100f;
    }

    IEnumerator DecreaseWarning()
    {
        yield return new WaitForSeconds(15);
        worldData.warning -= 10;
        isDecreasing = false;
    }

}
