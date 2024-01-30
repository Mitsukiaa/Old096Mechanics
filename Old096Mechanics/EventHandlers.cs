using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;

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
                ev.Scp096.Enrage();
            }
        }
    }
}