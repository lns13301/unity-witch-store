using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStatConsume
{
    public double recoveryHP;
    public double recoveryMP;

    private ItemStatConsume()
    {
    }

    public class Builder
    {
        public double recoveryHP;
        public double recoveryMP;

        public Builder()
        {
        }

        public Builder RecoveryHP(double recoveryHP)
        {
            this.recoveryHP = recoveryHP;
            return this;
        }

        public Builder RecoveryMP(double recoveryHP)
        {
            this.recoveryHP = recoveryHP;
            return this;
        }

        public ItemStatConsume build()
        {
            return new ItemStatConsume(this);
        }
    }

    public ItemStatConsume(Builder builder)
    {
        this.recoveryHP = builder.recoveryHP;
        this.recoveryMP = builder.recoveryMP;
    }
}