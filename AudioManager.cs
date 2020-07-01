using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Praedonum
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class AudioManager : Microsoft.Xna.Framework.GameComponent
    {
        private SoundBank m_soundBank;
        private WaveBank m_waveBank;
        private AudioEngine m_audioEngine;

        private List<Cue> m_sounds;


        public AudioManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
#if WINDOWS
            m_audioEngine = new AudioEngine("Content/Audio/Praedonum.xgs");
            m_waveBank = new WaveBank(m_audioEngine, "Content/Audio/Wave Bank.xwb");
            m_soundBank = new SoundBank(m_audioEngine, "Content/Audio/Sound Bank.xsb");
#endif

#if XBOX
            // TODO CHANGE THESE
            m_audioEngine = new AudioEngine("Content/Xact Tower.xgs");
            m_waveBank = new WaveBank(m_audioEngine, "Content/WaveBank.xwb");
            m_soundBank = new SoundBank(m_audioEngine, "Content/SoundBank.xsb");
#endif

            m_sounds = new List<Cue>();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            m_audioEngine.Update();

            int index = 0;
            while (index < m_sounds.Count)
            {
                Cue cue = m_sounds[index];
                if (cue.IsStopped)
                {
                    cue.Dispose();
                    m_sounds.RemoveAt(index);
                }

                index++;
            }

            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public Cue GetCue(string cueName)
        {
            Cue cue = m_soundBank.GetCue(cueName);
            return cue;
        }

        public void PlayCue(Cue c)
        {
            c.Play();
            m_sounds.Add(c);

        }

        public Cue PlaySound(string cueName)
        {
            Cue cue = m_soundBank.GetCue(cueName);
            cue.Play();
                       
           
            m_sounds.Add(cue);

            return cue;
        }

        public bool StopSound(string cueName)
        {
            foreach (Cue cue in m_sounds)
            {
                if (cue.Name == cueName)
                {
                    cue.Stop(AudioStopOptions.Immediate);
                    return true;
                }
            }

            return false;
        }

        public float GetParameter(string cueName, string parameterName)
        {
            foreach (Cue cue in m_sounds)
            {
                if (cue.Name == cueName)
                {
                    return cue.GetVariable(parameterName);
                }
            }

            return -1000.0f;
        }

        public bool SetParameter(string cueName, string parameterName, float value)
        {
            foreach (Cue cue in m_sounds)
            {
                if (cue.Name == cueName)
                {
                    cue.SetVariable(parameterName, value);
                    
                    return true;
                }
            }

            return false;
        }
    }
}
