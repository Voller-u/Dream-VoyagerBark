using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 成就系统
/// </summary>
public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private AchievementCenter achievementCenter;

    public string path = Application.streamingAssetsPath + "/Achievement/achievement";
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);

        Init();

        for (int i=0;i<achievementCenter.achievementList.Count;i++)
        {
            achievementCenter.achievementList[i].AchievementListener();
        }

        EventManager.Instance.OnDestroySaveEvent +=()=> Tools.SaveClass<AchievementCenter>(achievementCenter, path);
    }

    public void Init()
    {
        try
        {
            achievementCenter = Tools.ReadClass<AchievementCenter>(path);
        }
        catch(FileNotFoundException)
        {
            Debug.Log("文件不存在，重新创建成就");
            InitAchievements();
        }
    }

    public void InitAchievements()
    {
        achievementCenter.achievementList.Add(
            new GoldAchievement(
                "好臭的金币",
                "累计获得114514金币",
                114514,
                0
            ));
    }
    private void OnApplicationQuit()
    {
        
    }
}
