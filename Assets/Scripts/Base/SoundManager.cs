using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance;
    // 用于播放音乐
    private AudioSource audioSource;
    // 
    private Dictionary<string, AudioClip> dictAudio;

    private float _BGMVolume = 1f;
    public float BGMVolume
    {
        set
        {
            _BGMVolume = value;
            audioSource.volume = _BGMVolume;
        }
    }
    public float SoundVolume = 1f;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();

        PlayBGM(Global.MainMenuBGM);

        DontDestroyOnLoad(gameObject);

        EventManager.Instance.OnSceneLoadEvent2 += (string sceneName) =>
        {
            if (sceneName.Equals("Game"))
                PlayBGM(Global.MainMenuBGM);
            else if (sceneName.Equals("MainMenu"))
                PlayBGM(Global.MainMenuBGM);
        };
    }

    // 辅助函数： 加载音频，需要确保音频文件的路径在Resources文件夹下
    public AudioClip LoadAudio(string path)
    {
        var clip = Resources.Load<AudioClip>(path);
        return clip;
    }

    // 辅助函数：获取音频，并且将其缓存在dictAudio中，避免重复加载
    private AudioClip GetAudio(string path)
    {
        if (!dictAudio.ContainsKey(path))
        {
            AudioClip clip = LoadAudio(path);
            if (clip != null)
                dictAudio[path] = clip;
            else
                return null;
        }
        return dictAudio[path];
    }

    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.clip = GetAudio(name);

        audioSource.volume = volume;
        audioSource.Play();

    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    // 播放音效
    public void PlaySound(string path, float volume = 1f)
    {
        // PlayOneShot可以叠加播放
        this.audioSource.PlayOneShot(GetAudio(path), volume);

        // this.audioSource.volume = volume;
    }

    //public void PlaySound(AudioSource audioSource, string path, float volume = 1f)
    //{
    //  audioSource.PlayOneShot(GetAudio(path), volume);
    //  // audioSource.volume = volume;
    //}

    public void PlaySoundOfDialog(string path, float volume = 1f)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(GetAudio(path), volume);
        // audioSource.volume = volume;
    }

    public void Stop()
    {
        audioSource.Stop();
    }

}
