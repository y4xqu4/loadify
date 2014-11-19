Loadify
=======
Loadify is (yet another) Spotify downloader written in .NET for downloading playlists and tracks from Spotify.
Please keep in mind that the software is still work-in-progress. Let us know if you encounter any problems or if our documentation is missing information.

Problem
-
Spotify offers a special feature for premium users: the offline mode. Using offline mode, you are able to download tracks by storing them locally on your harddrive, so listening to music is possible without internet connection.

Why should you use a software to download tracks if Spotify already offers downloading? 
Spotify encrypts the downloaded songs, to ensure they are not copied or played outside Spotify.
Also your songs are unplayable if your premium subscribtion expires.

Solution
-
Because Spotify's downloads are encrypted, we need to jump in a little bit earlier.
We're using **libspotify**, the official Spotify library written in C and a C# wrapper that manages the transition from unmanaged to managed by marshalling. Since audio data is streamed into some type of callback we just need to load a track into the audio player, and capture the data flying into it. The track is saved as `wave` file into a specified folder and then converted to a `MP3` file.

Features
-
### User friendly, simple, beautiful
While this is unimportant for many other developers, it was very important for us to keep things as simple as possible.

***

### Login and Authentication
The login is inspired by the official client. You just enter your username and password you'd normally use for logging into Spotify and click on `Login`. Please note that the _Remember me_ option works fine but still stores your password unencrypted. If you´re sharing your computer with other people, you shouldn't use this option.

![](http://i.epvpimg.com/nwv4f.png)


***

### Dashboard
After logging in, your dashboard will open up. 
The software will fetch your playlists and display them in the left pane. 

![](http://i.epvpimg.com/yQNWf.jpg)

The right pane is mainly used for configuration and settings. 
You may (currently) specify:
* where to store downloaded tracks
* where to store cache files for speeding up the login/playlist progress

Once you've selected some tracks (or playlists), the `Download` button will appear.

![](http://i.epvpimg.com/dRiYg.jpg)


***

### Resizable Panes
Playlist or track names are too long to be fully displayed? 
That's no problem because the whole interface can be resized to your needs.
Just grab the green bar drag it to the left or right.

![](http://i.epvpimg.com/ID1Yg.jpg)


***

### Tracks and Playlists
Once you expand a playlist in the left pane, all associated tracks will be listed in the following format:

`<Artists> - <Track name>`

If you hover over tracks, a tooltip will display the track duration.

![](http://i.epvpimg.com/RWiqf.jpg)

Each time you select a track, the software calculates the approximate time needed for downloading all selected tracks. The estimated time is displayed below the playlist/track listings.

You might note a red cross in front of some tracks. 
This is an indicator that the track already exists in your specified download directory.

Once you start the download, the status bar in the lower left corner will become visible informing you about the current download status: 

* The progress bar represents the status of the current download.
* Next to the progress bar you'll see a status indicator:
  
`<Artists> - <Title> (DownloadedTracks / SelectedTracks)`

<a href="url"><img src="http://i.epvpimg.com/aQLme.jpg" align="center" height="100%" width="700"></a>


***


### Local Track detection
Existing Tracks will be detected if:
* the filename matches the output format of music files converted by Loadify - `<Artists> - <Track name>`
* the format equals the format used by loadify (currently mp3)
* the file is located within the playlist's subdirectory (`DownloadDirectory/Playlist/David Guetta - Alphabeat.mp3`)

If a red cross is shown, the track does not exist (or simply wasn't found). If a green tick is shown, the track exists locally. If you select a whole playlist to download loadify will ask if you want to remove the existing tracks or not.

![](http://i.epvpimg.com/OCJgf.jpg)

***

### Searching tracks
Sometimes you don't want to browse your playlists to find a certain track. 
Simply use the search box above your tracklist.

Note: The search is __case insensitive__

![](http://i.epvpimg.com/gETFe.jpg)

***

### Adding playlists and tracks
If you want to download playlists/tracks that are not in your spotify account, you can temporarily or permanently add them to loadify to download them.

#### Playlists
Right click an empty area of the tracklist and click  __Add Playlist__

![](http://i.epvpimg.com/zOLIh.jpg)

A dialog will prompt you to enter the playlist's link you want to add.
Spotify uses 2 types of links:
* HTTP links (example: __http://open.spotify.com/user/spotify_germany/playlist/0QUQf1xMMbtArIbDjwi2Hf__)
* Spotify links (example: __spotify:user:spotify_germany:playlist:0QUQf1xMMbtArIbDjwi2Hf__)

![](http://i.epvpimg.com/8qh1g.jpg)

After the url is entered, loadify will ask you if you want to add the playlist permanently to your Spotify account.
If you don't add playlist permanently it will be removed after the next refresh.

![](http://i.epvpimg.com/yKqlh.jpg)


#### Tracks
To add tracks into an existing playlist, you need to right click one of the playlists and select __Add Track__. 
Again spotify uses the 2 link types:
* HTTP links (example: __http://open.spotify.com/track/1B20QutZwNPRrlQ2tDKuOe__)
* Spotify links (example: __spotify:track:1B20QutZwNPRrlQ2tDKuOe__)

![](http://i.epvpimg.com/GAbHc.jpg)
***
![](http://i.epvpimg.com/469De.jpg)
