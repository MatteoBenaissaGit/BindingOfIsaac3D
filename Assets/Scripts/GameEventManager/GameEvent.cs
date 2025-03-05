using System;
using System.Collections.Generic;
using MBLib.GameEventManager.Effects;
using UnityEngine;

namespace MBLib.GameEventManager
{
    [CreateAssetMenu(menuName = "Game Event")]
    [Serializable]
    public class GameEvent : ScriptableObject
    {
        [SerializeReference] public List<GameEffect> GameEffects = new();
        
        public List<string> ParametersKnown { get; set; } = new();
    }
}
