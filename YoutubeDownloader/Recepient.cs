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
    public class Recepient
    {
        YoutubeClient youtube = new();
        public string VideoName { get; set; }
        VideoId videoId;

        bool ValidateVideo()
        {
            try
            {
                this.videoId = VideoId.Parse(this.VideoName);
                Console.WriteLine($"Поиск видео: {videoId}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Видео \"{this.VideoName}\" не найдено. Ошибка: {ex.Message}");
                return false;
            }
        }
        public void GetVideoInfo()
        {
            if (!ValidateVideo()) return;

            var info = youtube.Videos.GetAsync(videoId);
            Console.WriteLine(info.Result.Description);
        }
        public async Task Download()
        {
            if (!ValidateVideo()) return;

            try
            {
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                if (streamInfo is null)
                {
                    Console.Error.WriteLine("В видео нет мульти потоков.");
                    return;
                }

                Console.WriteLine($"Загружаем стрим: {streamInfo.Container.Name}");
                var fileName = $"{videoId}.{streamInfo.Container.Name}";
                await youtube.Videos.Streams.DownloadAsync(streamInfo, fileName);
                Console.WriteLine($"Видео сохранено '{fileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке видео: {ex.Message}");
            }
        }
    }
}
