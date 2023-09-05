using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static YoutubeDownloader.Program;

namespace YoutubeDownloader
{
    public class ComandInfo : ICommand
    {
        Recepient recepient;
        public ComandInfo(Recepient recepient, string videoName)
        {
            this.recepient = recepient;
            this.recepient.VideoName = videoName;
        }

        public async Task Execute() => recepient.GetVideoInfo();
    }
}
