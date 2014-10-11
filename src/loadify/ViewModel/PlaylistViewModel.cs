﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using loadify.Event;
using loadify.Model;
using SpotifySharp;

namespace loadify.ViewModel
{
    public class PlaylistViewModel : ViewModelBase, IHandle<TrackSelectedEvent>
    {
        private PlaylistModel _Playlist;
        public PlaylistModel Playlist
        {
            get { return _Playlist; }
            set
            {
                if (_Playlist == value) return;
                _Playlist = value;
                NotifyOfPropertyChange(() => Playlist);
            }
        }

        private ObservableCollection<TrackViewModel> _Tracks;
        public ObservableCollection<TrackViewModel> Tracks
        {
            get { return _Tracks; }
            set
            {
                if (_Tracks == value) return;
                _Tracks = value;
                NotifyOfPropertyChange(() => Tracks);
            }
        }

        public string Name
        {
            get { return Playlist.Name; }
            set
            {
                if (Playlist.Name == value) return;
                Playlist.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Description
        {
            get { return Playlist.Description; }
            set
            {
                if (Playlist.Description == value) return;
                Playlist.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public string Creator
        {
            get { return Playlist.Creator; }
            set
            {
                if (Playlist.Creator == value) return;
                Playlist.Creator = value;
                NotifyOfPropertyChange(() => Creator);
            }
        }

        public bool Selected
        {
            get { return Tracks.All(track => track.Selected); }
            set
            {
                foreach (var track in Tracks)
                    track.Selected = value;

                NotifyOfPropertyChange(() => Selected);
            }
        }

        public ObservableCollection<TrackViewModel> SelectedTracks
        {
            get { return new ObservableCollection<TrackViewModel>(Tracks.Where(track => track.Selected)); }
        }

        public PlaylistViewModel(PlaylistModel playlist, IEventAggregator eventAggregator):
            base(eventAggregator)
        {
            _Playlist = playlist;
            _Tracks = new ObservableCollection<TrackViewModel>(playlist.Tracks.Select(track => new TrackViewModel(track, eventAggregator)));
        }

        public PlaylistViewModel(IEventAggregator eventAggregator):
            this(new PlaylistModel(), eventAggregator)
        { }

        public void Handle(TrackSelectedEvent message)
        {
            NotifyOfPropertyChange(() => SelectedTracks);
        }
    }
}