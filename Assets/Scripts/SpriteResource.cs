using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteResource
{
    public string spritePath;
    public Sprite sprite;

    public SpriteResource(string spritePath, Sprite sprite)
    {
        this.spritePath = spritePath;
        this.sprite = LoadSprite(spritePath);
    }

    private Sprite LoadSprite(string spritePath)
    {
        return Resources.Load<Sprite>(spritePath);
    }
}
