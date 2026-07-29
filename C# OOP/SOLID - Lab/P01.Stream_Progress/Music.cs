namespace P01.Stream_Progress
{
    public class Music : File
    {
        private string artist;
        private string album;

        public Music(string name, int length, int bytesSent) : base(name, length, bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
