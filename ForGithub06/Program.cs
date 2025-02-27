using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGithub06
{

    class VideoInfo
    {

        public string Name { get; set; }
        public string ChannelName { get; set; }
    }


    class VideoUploaderCompletedEventArgs : EventArgs
    {
        public VideoInfo VideoInfo { get; set; }

        public VideoUploaderCompletedEventArgs(VideoInfo videoInfo)
        {
            VideoInfo = videoInfo;
        }



    }

    class VideoUploader
    {
        public event EventHandler<VideoUploaderCompletedEventArgs> VideoUploadCompleted;
        public void Upload(VideoInfo videoInfo)
        {
            Console.WriteLine($"Uploading {videoInfo.Name} video");


            if (VideoUploadCompleted != null)
            {
                VideoUploadCompleted.Invoke(this, new VideoUploaderCompletedEventArgs(videoInfo));

            }


        }

    }

    internal class Program
    {
        static void Transform(object sender, VideoUploaderCompletedEventArgs e)
        {
            Console.WriteLine($"Transforming {e.VideoInfo.Name}  to multiple resolutions");
        }


        static void Analyze(object sender, VideoUploaderCompletedEventArgs e)
        {
            Console.WriteLine($"Analyzing {e.VideoInfo.Name} content");
        }


        static void SendNotificationToSubscribers(object sender, VideoUploaderCompletedEventArgs e)
        {
            Console.WriteLine($"Sending notification to customers for subscruption of channel {e.VideoInfo.ChannelName}");
        }
        static void Main(string[] args)
        {

            VideoUploader uploader = new VideoUploader();
            VideoInfo info = new VideoInfo
            {
                Name = "C# programming , events and delegates",
                ChannelName = "Programming from zero"

            };
            uploader.VideoUploadCompleted += Transform;
            uploader.VideoUploadCompleted += Analyze;
            uploader.VideoUploadCompleted += SendNotificationToSubscribers;
            uploader.Upload(info);

        }
    }
}
