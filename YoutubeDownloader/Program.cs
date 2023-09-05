using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System.Collections.Generic;

namespace YoutubeDownloader
{
    class Program
    {
        static async Task Main()
        {            
            string nameVideo;
            Recepient recepient = new();
            SendComand sender = new();

            while (true)
            {
                Console.WriteLine("Введите ссылку на видео");
                nameVideo = Console.ReadLine();

                Console.WriteLine("1 - получить информацию о видео, 2 - загрузить видео");
                switch (Console.ReadLine())
                {
                    case "1":
                        ComandInfo infoResult = new(recepient, nameVideo);
                        sender.SetCommand(infoResult);
                        await sender.Execute();
                        break;

                    case "2":
                        DownloadComand downloadComand = new(recepient, nameVideo);
                        sender.SetCommand(downloadComand);
                        await sender.Execute();
                        break;

                    default: return;
                }
            }
        }

    }
}