using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    /// <summary>
    /// Provides an easy wrapper to looping audio sources with nice transitions for volume when starting and stopping
    /// </summary>
    public class LoopingAudioSource
    {

        private float startMultiplier;
        private float stopMultiplier;
        private float currentMultiplier;

    }

    /// <summary>
    /// Script for objects such as wall of fire that never expire unless manually stopped
    /// </summary>
    public class FireConstantBaseScript : FireBaseScript
    {
        [HideInInspector]
        public LoopingAudioSource LoopingAudioSource;

        protected override void Awake()
        {
            base.Awake();

            // constant effect, so set the duration really high and add an infinite looping sound
            Duration = 999999999;
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Start()
        {
            base.Start();

        }

        public override void Stop()
        {

            base.Stop();
        }
    }
}