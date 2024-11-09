using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance;
    // ���ڲ�������
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

    // ���������� ������Ƶ����Ҫȷ����Ƶ�ļ���·����Resources�ļ�����
    public AudioClip LoadAudio(string path)
    {
        var clip = Resources.Load<AudioClip>(path);
        return clip;
    }

    // ������������ȡ��Ƶ�����ҽ��仺����dictAudio�У������ظ�����
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

    // ������Ч
    public void PlaySound(string path, float volume = 1f)
    {
        // PlayOneShot���Ե��Ӳ���
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
