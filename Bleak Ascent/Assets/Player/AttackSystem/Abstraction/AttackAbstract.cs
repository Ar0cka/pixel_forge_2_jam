using UnityEngine;

namespace Player.AttackSystem.Abstraction
{
    public abstract class AttackAbstract<TConfig, TInfo> where TInfo : AttackInfo
    {
        protected float CooldownTime;
        public float Cooldown => CooldownTime;
        
        protected TConfig Config;

        protected TInfo Info;

        public virtual void Initialize(TInfo info, TConfig config)
        {
            Config = config;
            Info = info;
        }

        public abstract void Execute();

        public void MinesCooldown(float time)
        {
            CooldownTime -= time;
        }

        protected bool CanExecute()
        {
            return CooldownTime <= 0;
        }
    }
}