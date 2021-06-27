using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemContent
{
    public string english;
    public string korean;

    public ItemContent(string english, string korean)
    {
        this.english = english;
        this.korean = korean;
    }

    public class Builder
    {
        public string english;
        public string korean;

        public Builder()
        {
        }

        public Builder English(string english)
        {
            this.english = english;
            return this;
        }

        public Builder Korean(string korean)
        {
            this.korean = korean;
            return this;
        }

        public ItemContent build()
        {
            return new ItemContent(this);
        }
    }

    public ItemContent(Builder builder)
    {
        this.english = builder.english;
        this.korean = builder.korean;
    }

    public string GetName(Language language)
    {
        switch (language)
        {
            case Language.KOREAN:
                return korean;
            default:
                return english;
        }
    }
}