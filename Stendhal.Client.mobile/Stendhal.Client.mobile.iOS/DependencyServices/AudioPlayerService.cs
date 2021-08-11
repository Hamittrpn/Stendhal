using AVFoundation;
using Foundation;
using Stendhal.Client.mobile.DependencyServices;
using Stendhal.Client.mobile.iOS.DependencyServices;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace Stendhal.Client.mobile.iOS.DependencyServices
{
    public class AudioPlayerService : IAudioPlayerService
	{
		private AVAudioPlayer _audioPlayer = null;
		public Action OnFinishedPlaying { get; set; }

		public AudioPlayerService()
		{
		}

		public void Play(string pathToAudioFile)
		{
			if (_audioPlayer != null)
			{
				_audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
				_audioPlayer.Stop();
			}

			string localUrl = pathToAudioFile;
			_audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
			_audioPlayer.FinishedPlaying += Player_FinishedPlaying;
			_audioPlayer.Play();
		}

		private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
		{
			OnFinishedPlaying?.Invoke();
		}

		public void Pause()
		{
			_audioPlayer?.Pause();
		}

		public void Play()
		{
			_audioPlayer?.Play();
		}
	}
}