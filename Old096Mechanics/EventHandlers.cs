using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using PlayerRoles.PlayableScps.Scp096;

namespace Old096Mechanics
{
    public class EventHandlers
    {
        public void OnHurting(HurtingEventArgs ev)
        {
            if (Old096Mechanics.Instance.Config.Instakill)
            {
                if (ev.Attacker.Role.Type == PlayerRoles.RoleTypeId.Scp096)
                {
                    ev.Amount = 100f;
                }
            }
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (Old096Mechanics.Instance.Config.ForceEnrageWhenLookedAt)
            {
                if (ev.Scp096.RageState != Scp096RageState.Enraged && ev.Scp096.RageState != Scp096RageState.Distressed) return;
                ev.Scp096.Enrage();
            }
        }
    }
}