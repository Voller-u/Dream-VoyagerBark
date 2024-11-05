using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class EventManager : BaseManager<EventManager>
{
    public event UnityAction OnSceneLoadEvent;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneLoadEvent?.Invoke();
    }
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        OnSceneLoadEvent?.Invoke();
    }

    public event UnityAction<Role> OnPropertyChangeEvent;
    public void OnPropertyChange(Role role)
    {
        OnPropertyChangeEvent?.Invoke(role);
    }

    public event UnityAction OnDestroySaveEvent;
    public void OnDestroySave()
    {
        OnDestroySaveEvent?.Invoke();
    }

    /// <summary>
    /// 成就完成时调用的事件
    /// </summary>
    public event UnityAction<Achievement> OnAchievementCompletedEvent;
    public void OnAchievementCompleted(Achievement achievement)
    {
        OnAchievementCompletedEvent?.Invoke(achievement);
    }

    /// <summary>
    /// 获得金币时调用的事件
    /// </summary>
    public event UnityAction<int> OnGoldObtainEvent;
    public void OnGoldObtain(int obtainNum)
    {
        Debug.Log("获得金币事件调用");
        OnGoldObtainEvent?.Invoke(obtainNum);
    }

    public event UnityAction<Card> OnCardPlayEvent;
    public void OnCardPlay(Card card)
    {
        OnCardPlayEvent?.Invoke(card);
    }
}
