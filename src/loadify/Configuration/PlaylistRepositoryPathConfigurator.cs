﻿using System;
using System.IO;
using System.Linq;
using loadify.Model;
using loadify.Spotify;

namespace loadify.Configuration
{
    public class PlaylistRepositoryPathConfigurator : IDownloadPathConfigurator
    {
        public string Configure(string basePath, string targetFileExtension, TrackModel track)
        {
            basePath += (basePath.Last() != '\\') ? "\\" : "";
            var completePath = basePath + track.Name.ValidateFileName();

            if (track.Playlist == null) return completePath;
            if (track.Playlist.Name.Length == 0) return completePath;

            var playlistRepositoryDirectory = basePath + track.Playlist.Name.ValidateFileName() + "\\";
            try
            {
                if (!Directory.Exists(playlistRepositoryDirectory))
                    Directory.CreateDirectory(playlistRepositoryDirectory);
            }
            catch (UnauthorizedAccessException exception)
            {
                throw new ConfigurationException(String.Format("Loadify konnte das Downloadverzeichnis ({0}) leider nicht erstellen.", playlistRepositoryDirectory), exception);
            }
            catch (Exception exception)
            {
                throw new ConfigurationException("Ein unbekannter Konfigurationsfehler ist aufgetreten: ", exception);
            }

            completePath = playlistRepositoryDirectory + track.Name.ValidateFileName() + "." + targetFileExtension;
            return completePath;
        }
    }
}
