using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public WorldData_SO worldData_SO;
    private float second = 0;
    [SerializeField] private PlayerData_SO playerData_SO;
    [SerializeField] private WorldData_SO worldData;

    [Header("道具检查")]
    public bool hasBrand;
    public bool hasTool;
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
        TimeCount();
    }
    /// <summary>
    /// 1秒钟 = 4分钟
    /// </summary>
    public void TimeCount()
    {
        second += Time.deltaTime;
        if (second >= 1)
        {
            worldData.worldTime -= 1;
            second = 0;
        }
    }

}
