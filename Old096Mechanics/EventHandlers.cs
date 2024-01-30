using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Old096Mechanics.Components;

namespace Old096Mechanics
{
    public class EventHandlers
    {
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (Old096Mechanics.Instance.Config.Instakill)
            {
                if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.Scp096)
                {
                    Log.Debug("A player with 096 role has been found, adding InstaKill component.");
                    ev.Player.GameObject.AddComponent<InstaKill>();
                }
                else
                {
                    if (ev.Player.ReferenceHub.TryGetComponent(out InstaKill ikComp))
                    {
                        Log.Debug("A human with InstaKill component has been found, removing.");
                        UnityEngine.Object.Destroy(ikComp);
                    }
                }
            }
        }
    }
}