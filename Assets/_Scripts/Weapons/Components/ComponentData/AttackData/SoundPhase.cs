using System;
using UnityEngine;
using System.Linq;

namespace Bardent.Weapons.Components
{
    [Serializable]
    public class SoundPhase : AttackData
    {
        [field: SerializeField] public PhaseSound[] phaseSound { get; private set; }
    }

    [Serializable]
    public struct PhaseSound
    {
        [field: SerializeField] public AttackPhases Phase { get; private set; }
        
        [field: SerializeField] public AudioClip[] AudioClip { get; private set; }
    }
}
