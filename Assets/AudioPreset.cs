using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent
{
    public class AudioPreset : MonoBehaviour
    {
        [SerializeField] private AudioClip[] clips;

        private AudioSource source;
        // Start is called before the first frame update
        void Start()
        {
            source = GetComponent<AudioSource>();  
        }

        // Update is called once per frame
        void Update()
        {
           source.clip = clips[Random.Range(0, clips.Length)];
        }
    }
}
