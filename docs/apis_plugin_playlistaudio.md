# Playlist Audio
> The plugin will be plays, in background mode, a playlist of audio file (MP3, WAV) on LEDbox. The playlist of images cans will be play in infinity loop or based by a timer. 

# SetPlaylistAudio

> Set parameters of playlist

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "SetPlaylistAudio",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": <playlist> //playlist parameters
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "SetPlaylistAudio",
"value": <playlist>
}
```

<!--  tabs:end  -->

# StartPlaylistAudio

> Start to play the playlist

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "StartPlaylistAudio",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": {
        "hashname": <string>, //id of playlist
        "title": <string> //title of playlist
    }
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "StartPlaylistAudio",
"value": {
        "hashname": <string>, //id of playlist
        "title": <string> //title of playlist
    }
}
```

<!--  tabs:end  -->

# PausePlaylistAudio

> Set the current playlist in pause

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "PausePlaylistAudio",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": {
        "hashname": <string>, //id of the playlist 
    }
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "PausePlaylistAudio",
"value": {
        "hashname": <string>, //id of the playlist
    }
}
```

<!--  tabs:end  -->

# StopPlaylistAudio

> Stop the playlist and show a "waiting" layout

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "StopPlaylistAudio",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "StopPlaylistAudio",
"value": {
        "hashname": <string>, //id of playlist
        "title": <string> //title of playlist
    }
}
```

<!--  tabs:end  -->


# GetListPlaylistAudio

> Get a list of all playlist contains on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "GetListPlaylistAudio",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "GetListPlaylistAudio",
"value": {
        [{
            "hashname":<string>, //id of playlist
            "title":<string>, //title of playlist
            "current_status":<int>, // state of playlist (0 = not playing; 1 = playing; 2 = pause)
            "type": <int> //type of playlist (2 = audio)
        }]
    }
}
```

<!--  tabs:end  -->

# UploadPlaylistAudio

> Upload a playlist file on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"UploadPlaylistAudio",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "UploadPlaylistAudio",
    "value":<upload>
}
```

<!--  tabs:end  -->

# DeleteAllPlaylistAudio

> Delete all playlist of a username and sport on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"DeleteAllPlaylistAudio",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "DeleteAllPlaylistAudio",
    "value":true
}
```

<!--  tabs:end  -->