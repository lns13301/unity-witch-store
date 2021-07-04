using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private List<Sound> musics;
    [SerializeField] private List<Sound> effects;
    [SerializeField] private List<Sound> voices;
    [SerializeField] private List<Sound> playingMusics;
    [SerializeField] private List<Sound> playingEffects;
    [SerializeField] private List<Sound> playingVoices;

    public Dictionary<string, List<Sound>> soundMap;

    public int timer;

    private void Awake()
    {
        instance = this;

        musics = new List<Sound>();
        effects = new List<Sound>();
        voices = new List<Sound>();
        soundMap = new Dictionary<string, List<Sound>>();

        // 음악 등록
        RegisterSound(transform.GetChild(0), musics, SoundType.MUSIC);
        // 효과음 등록
        RegisterSound(transform.GetChild(1), effects, SoundType.EFFECT);
        // 보이스 등록
        RegisterSound(transform.GetChild(2), voices, SoundType.VOICE);
    }

    private void RegisterSound(Transform targetTransform, List<Sound> sounds, SoundType soundType)
    {
        for (int i = 0; i < targetTransform.childCount; i++)
        {
            Sound sound = RegisterSoundEach(targetTransform.GetChild(i).GetComponent<Sound>(), soundType);
            try
            {
                RegisterMap(sound.soundName, sound);
            }
            catch
            {
                RegisterMap(sound.gameObject.name, sound);
            }
        }
    }

    private Sound RegisterSoundEach(Sound sound, SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.VOICE:
                voices.Add(sound);
                return sound;
            case SoundType.MUSIC:
                musics.Add(sound);
                return sound;
            default:
                effects.Add(sound);
                return sound;
        }
    }

    private void RegisterMap(String key, Sound sound)
    {
        if (soundMap.ContainsKey(key))
        {
            soundMap[key].Add(sound);
        }
        else
        {
            soundMap.Add(key, new List<Sound>() {sound});
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
    
    public void PlayVoiceSound(int index)
    {
        Sound sound = voices[index];
        sound.PlaySound();
        playingVoices.Add(sound);
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
    
    public void PlayOneShotVoiceSound(int index)
    {
        Sound sound = voices[index];
        sound.StopSound();
        sound.PlaySound();
        playingVoices.Add(sound);
        DistinctSounds();
    }

    public void PlayEffectFindByName(string name)
    {
        try
        {
            Sound sound = PickRandomSound(soundMap[name]);
            sound.PlaySound();
            playingEffects.Add(sound);
            DistinctSounds();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("찾을 수 없음: " + name);
        }
    }
    
    public void PlayVoiceFindByName(string name)
    {
        try
        {
            Sound sound = PickRandomSound(soundMap[name]);
            sound.PlaySound();
            playingVoices.Add(sound);
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
            Sound sound = PickRandomSound(soundMap[name]);

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
            Sound sound = PickRandomSound(soundMap[name]);
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
            Sound sound = PickRandomSound(soundMap[name]);
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
        playingVoices = new List<Sound>(new HashSet<Sound>(playingVoices));
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
        
        for (var i = playingVoices.Count - 1; i > -1; i--)
        {
            Sound sound = playingVoices[i];
            sound.StopSound();
            playingVoices.Remove(sound);
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

    public Sound PickRandomSound(List<Sound> sounds, bool isSelected = false, int selectedIndex = 0)
    {
        if (sounds.Count == 0)
        {
            throw new IndexOutOfRangeException("Empty sound index out of bound!");
        }

        if (isSelected)
        {
            return sounds[selectedIndex];
        }
        
        if (sounds.Count == 1)
        {
            return sounds[0];
        }
        return MyStream<Sound>.Of(sounds).Shuffle().ToList()[0];
    }
}

public enum SoundType
{
    MUSIC,
    EFFECT,
    VOICE
}
