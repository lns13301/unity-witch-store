using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteResource
{
    public string spritePath;
    public Sprite sprite;

    public SpriteResource(string spritePath)
    {
        this.spritePath = spritePath;

        sprite = LoadSprite(spritePath);
    }

    private Sprite LoadSprite(string spritePath)
    {
        return Resources.Load<Sprite>(spritePath);
    }
}
