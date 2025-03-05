using System;
using System.Collections.Generic;
using MBLib.GameEventManager.Effects;
using MBLib.SingletonClassBase;

namespace MBLib.GameEventManager
{
    public class GameEventsManager : Singleton<GameEventsManager>
    {
        public List<GameEventInstance> Events = new();

        private static Dictionary<Guid, GameEventInstance> _eventsId = new();

        private void Update()
        {
            foreach (GameEventInstance toKillEvent in ToKillEvents)
            {
                Events.Remove(toKillEvent);
            }
            
            foreach (GameEventInstance eventInstance in Events)
            {
                eventInstance.Update();
            }
        }

        public static Guid PlayEvent(GameEvent @event, params (string name, object value)[] parameters)
        {
            GameEventInstance eventInstance = new GameEventInstance
            {
                GameEffects = new List<GameEffect>(@event.GameEffects)
            };

            eventInstance.SetBaseParameters(parameters);
            eventInstance.Initialize();

            Instance.Events.Add(eventInstance);

            Guid id = Guid.NewGuid();
            _eventsId.Add(id, eventInstance);
            return id;
        }

        public List<GameEventInstance> ToKillEvents { private get; set; } = new ();
        public static void KillEvent(GameEventInstance gameEventInstance)
        {
            Instance.ToKillEvents.Add(gameEventInstance);
        }

        public static void KillEvent(Guid eventId)
        {
            GameEventInstance eventToKill = _eventsId[eventId];
            KillEvent(eventToKill);
        }
    }
}