using Exiled.API.Features;
using UnityEngine;
using Handlers = Exiled.Events.Handlers;
using Exiled.Events.EventArgs.Player;
using PlayerStatsSystem;

namespace Old096Mechanics.Components
{
    public class InstaKill : MonoBehaviour // Code taken from AT: https://github.com/Exiled-Team/AdminTools/blob/master/AdminTools/Components/InstantKillComponent.cs
    {
        public Player Player;
        
        public void Awake()
        {
            Player = Player.Get(gameObject);
            Handlers.Player.Hurting += RunWhenPlayerIsHurt;
            Handlers.Player.Left += OnLeave;
            Old096Mechanics.Instance.IkHubs.Add(Player, this);
        }
        private void OnLeave(LeftEventArgs ev)
        {
            if (ev.Player == Player)
                Destroy(this);
        }
        public void OnDestroy()
        {
            Handlers.Player.Hurting -= RunWhenPlayerIsHurt;
            Handlers.Player.Left -= OnLeave;
            Old096Mechanics.Instance.IkHubs.Remove(Player);
        }
        public void RunWhenPlayerIsHurt(HurtingEventArgs ev)
        {
            if (ev.Attacker != ev.Player && ev.Attacker == Player)
                ev.Amount = StandardDamageHandler.KillValue;
        }
    }
}
