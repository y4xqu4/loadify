using System;

namespace loadify.Spotify
{
    public class InvalidSpotifyUrlException : Exception
    {
        public InvalidSpotifyUrlException(string url):
            base(url + " ist keine gültige Spotify-URL !")
        { }
    }
}
