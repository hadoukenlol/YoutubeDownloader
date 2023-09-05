using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloader
{
    public class DownloadComand : ICommand
    {
        Recepient recepient;
        public DownloadComand(Recepient recepient, string videoName)
        {
            this.recepient = recepient;
            this.recepient.VideoName = videoName;
        }

        public async Task Execute() => await recepient.Download();
    }
}
