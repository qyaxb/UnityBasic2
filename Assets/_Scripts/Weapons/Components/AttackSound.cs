using Bardent.Weapons.Components;
using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bardent.Weapons.Components
{
    public class AttackSound : WeaponComponent<AttackSoundData, SoundPhase>
    {
        public AudioSource baseAudioSource;
        public int currentAudioSourceIndex;
        
        public AudioClip[] currentSoundPhase;


        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAudioSourceIndex = 0;

        }
        private void HandleEnterAttackPhase(AttackPhases phase)
        {
            currentAudioSourceIndex = 0;

            currentSoundPhase = currentAttackData.phaseSound.FirstOrDefault(data => data.Phase == phase).AudioClip;

            if (currentAudioSourceIndex >= currentSoundPhase.Length)
            {
                Debug.LogWarning($"{weapon.name} weapon Sound length mismatch");
                return;
            }

            baseAudioSource.clip = currentSoundPhase[currentAudioSourceIndex];
            baseAudioSource.Play();
            currentAudioSourceIndex++;
        }
       
        protected override void Start()
        {
            base.Start();

            baseAudioSource = weapon.BaseGameObject.GetComponent<AudioSource>();

            data = weapon.Data.GetData<AttackSoundData>();

            AnimationEventHandler.OnEnterAttackPhase += HandleEnterAttackPhase;
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();


            AnimationEventHandler.OnEnterAttackPhase -= HandleEnterAttackPhase;
        }
    }
}
