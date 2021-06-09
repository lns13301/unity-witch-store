using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Language language;
    public PlayerPosition playerPosition;

    public string email;
    public string password;
    public long id;
    public string token;
    public string nickname;
    public long money;
    public int cash;

    public class Builder
    {
        // 필드 매개변수
        public string email;
        public string password;

        // 선택 매개변수 (기본값으로 초기화한다.)
        public Language language;
        public PlayerPosition playerPosition;
        public long id;
        public string token;
        public string nickname;
        public long money;
        public int cash;

        public Builder(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public Builder Language(Language language)
        {
            this.language = language;
            return this;
        }
        
        public Builder PlayerPosition(PlayerPosition playerPosition)
        {
            this.playerPosition = playerPosition;
            return this;
        }
        
        public Builder Id(long id)
        {
            this.id = id;
            return this;
        }
        
        public Builder Token(string token)
        {
            this.token = token;
            return this;
        }
        
        public Builder Nickname(string nickname)
        {
            this.nickname = nickname;
            return this;
        }
        
        public Builder Money(long money)
        {
            this.money = money;
            return this;
        }
        
        public Builder Cash(int cash)
        {
            this.cash = cash;
            return this;
        }
        
        public PlayerData build()
        {
            return new PlayerData(this);
        }
    }

    public PlayerData(Builder builder)
    {
        this.language = builder.language;
        this.playerPosition = builder.playerPosition;
        this.email = builder.email;
        this.password = builder.password;
        this.id = builder.id;
        this.token = builder.token;
        this.nickname = builder.nickname;
        this.money = builder.money;
        this.cash = builder.cash;
    }

    public void AddMoney(long itemValueSalePrice)
    {
        this.money += itemValueSalePrice;
    }
}