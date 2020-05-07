# Playlist Images
> The plugin will be plays, in background mode, a playlist of images ( JPG, PNG, GIF or animate GIF) on LEDbox. The playlist of images cans will be play in infinity loop or based by a timer. 

# SetPlaylistImage

> Set parameters of playlist

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "SetPlaylistImage",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": <playlist> //playlist parameters
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "SetPlaylistImage",
"value": <playlist>
}
```
<!--  tabs:end  -->

# StartPlaylistImage

> Start to play the playlist

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "StartPlaylistImage",
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
"sender": "StartPlaylistImage",
"value": {
        "hashname": <string>, //id of playlist
        "title": <string> //title of playlist
    }
}
```
<!--  tabs:end  -->

# PausePlaylistImage

> Set the current playlist in pause

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "PausePlaylistImage",
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
"sender": "PausePlaylistImage",
"value": {
        "hashname": <string>, //id of the playlist
    }
}
```
<!--  tabs:end  -->

# StopPlaylistImage

> Stop the playlist and show a "waiting" layout

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "StopPlaylistImage",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "StopPlaylistImage",
"value": {
        "hashname": <string>, //id of playlist
        "title": <string> //title of playlist
    }
}
```
<!--  tabs:end  -->


# GetListPlaylistImage

> Get a list of all playlist contains on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "GetListPlaylistImage",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "GetListPlaylistImage",
"value": {
        [{
            "hashname":<string>, //id of playlist
            "title":<string>, //title of playlist
            "current_status":<int>, // state of playlist (0 = not playing; 1 = playing; 2 = pause)
            "type": <int> //type of playlist (0 = image, 1 = video)
        }]
    }
}
```
<!--  tabs:end  -->

# UploadPlaylistImage

> Upload a playlist file on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"UploadPlaylistImage",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "UploadPlaylistImage",
    "value":<upload>
}
```
<!--  tabs:end  -->

# DeleteAllPlaylistImage

> Delete all playlist of a username and sport on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"DeleteAllPlaylistImage",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "DeleteAllPlaylistImage",
    "value":true
}
```
<!--  tabs:end  -->