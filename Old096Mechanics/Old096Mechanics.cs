using Exiled.API.Features;
using Old096Mechanics.Components;

namespace Old096Mechanics
{
    public class Old096Mechanics : Plugin<Config>
    {
        public static Old096Mechanics Instance { get; private set; }
        private EventHandlers Events { get; set; }
        // ---
        public override string Name => "Old096Mechanics";
        public override string Prefix { get; } = "Old096Mechanics";
        public override string Author { get; } = "Mitsu";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 3, 9);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Hurting += Events.OnHurting;
            Exiled.Events.Handlers.Scp096.AddingTarget += Events.OnAddingTarget;
            Instance = this;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= Events.OnHurting;
            Exiled.Events.Handlers.Scp096.AddingTarget -= Events.OnAddingTarget;
            Instance = null;
            Events = null;
            base.OnDisabled();
        }
    }
}