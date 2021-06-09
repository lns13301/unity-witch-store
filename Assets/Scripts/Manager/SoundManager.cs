using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private Sound[] musics;
    [SerializeField] private Sound[] effects;
    [SerializeField] private List<Sound> playingMusics;
    [SerializeField] private List<Sound> playingEffects;

    public Dictionary<string, Sound> soundMap;

    public int timer;

    private void Awake()
    {
        instance = this;

        musics = new Sound[transform.GetChild(0).childCount];
        effects = new Sound[transform.GetChild(1).childCount];
        soundMap = new Dictionary<string, Sound>();

        // 음악 등록
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            musics[i] = transform.GetChild(0).GetChild(i).GetComponent<Sound>();
            try
            {
                soundMap.Add(musics[i].soundName, musics[i]);
            }
            catch
            {
                soundMap.Add(musics[i].gameObject.name, musics[i]);
            }
        }

        // 효과음 등록
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            effects[i] = transform.GetChild(1).GetChild(i).GetComponent<Sound>();
            try
            {
                soundMap.Add(effects[i].soundName, effects[i]);
            }
            catch
            {
                soundMap.Add(effects[i].gameObject.name, effects[i]);
            }
        }
    }

    public void PlayMusic(int index, bool absoluteStart = false)
    {
        Sound sound = musics[index];
        
        sound.PlaySound(absoluteStart);
        playingMusics.Add(sound);
        DistinctSounds();
    }

    public void PlayEffectSound(int index)
    {
        Sound sound = effects[index];
        sound.PlaySound();
        playingEffects.Add(sound);
        DistinctSounds();
    }

    public void PlayOneShotEffectSound(int index)
    {
        Sound sound = effects[index];
        sound.StopSound();
        sound.PlaySound();
        playingEffects.Add(sound);
        DistinctSounds();
    }
    
    public void PlayEffectFindByName(string name)
    {
        try
        {
            Sound sound = soundMap[name];
            sound.PlaySound();
            playingEffects.Add(sound);
            DistinctSounds();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("찾을 수 없음: " + name);
        }
    }

    public void PlayMusicFindByName(string name, bool absoluteStart = false)
    {
        try
        {
            Sound sound = soundMap[name];
            
            if (absoluteStart)
            {
                sound.StopSound();
            }
            
            sound.PlaySound(absoluteStart);
            sound.GetComponent<AudioSource>().loop = true;
            playingMusics.Add(sound);
            DistinctSounds();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("찾을 수 없음: " + name);
        }
    }

    public void PlayOneShotMusicFindByName(string name)
    {
        try
        {
            Sound sound = soundMap[name];
            sound.StopSound();
            sound.PlaySound();
            playingMusics.Add(sound);
            DistinctSounds();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("찾을 수 없음: " + name);
        }
    }
    
    public void PlayOneShotEffectFindByName(string name)
    {
        try
        {
            Sound sound = soundMap[name];
            sound.StopSound();
            sound.PlaySound();
            playingEffects.Add(sound);
            DistinctSounds();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("찾을 수 없음: " + name);
        }
    }

    public void StopMusic(int index)
    {
        Sound sound = musics[index]; 
        sound.StopSound();
        playingMusics.Remove(sound);
    }
    
    public void PauseMusic(int index)
    {
        Sound sound = musics[index]; 
        sound.PauseSound();
    }

    public void StopEffectSound(int index)
    {
        Sound sound = effects[index]; 
        sound.StopSound();
        playingEffects.Remove(sound);
    }

    public void RefreshSounds()
    {
        CancelInvoke();
        StopAllSounds();
    }

    public void DistinctSounds()
    {
        playingMusics = new List<Sound>(new HashSet<Sound>(playingMusics));
        playingEffects = new List<Sound>(new HashSet<Sound>(playingEffects));
    }

    public void StopAllSounds(bool absoluteStop = false)
    {
        if (absoluteStop)
        {
            StopAllMusics();
        }
        else
        {
            PauseAllMusics();
        }
        
        for (var i = playingEffects.Count - 1; i > -1; i--)
        {
            Sound sound = playingEffects[i];
            sound.StopSound();
            playingEffects.Remove(sound);
        }
    }

    public void StopAllMusics()
    {
        for (var i = playingMusics.Count - 1; i > -1; i--)
        {
            Sound sound = playingMusics[i];
            sound.StopSound();
            playingMusics.Remove(sound);
        }
    }
    
    public void PauseAllMusics()
    {
        for (var i = playingMusics.Count - 1; i > -1; i--)
        {
            Sound sound = playingMusics[i];
            sound.PauseSound();
        }
    }

    public void PlayButtonEffectSound()
    {
        PlayEffectSound(0);
    }
}
