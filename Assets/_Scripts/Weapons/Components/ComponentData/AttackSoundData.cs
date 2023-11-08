using UnityEngine;
using Bardent.Weapons.Components;

namespace Bardent.Weapons.Components
{
    public class AttackSoundData : ComponentData<SoundPhase>
    {       

        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(AttackSound);
        }
    }
}