# Structures

# section
A section of layout

```json
{
"name": <string>, //name section,
"value":[<attrib>] //array of attributes of the section
}
```

# attrib
Attribute of section

```json
{
"attrib": <string>, //attribute name (ex. text, color, x, y ...),
"value":<string> //value of attribute
}
```

# horn
Attributes of sound
```json
{
"times": <int>, //number of sounds to play,
"sleep":<int> //pause in milliseconds between two sounds 
}
```

# config
LEDbox config parameter
```json
{
"section": <enum("NETWORK","WIFI","GENERAL","LAYOUT")>, //section of parameter
"field":<string>, //field name
"value":<string>, //value of parameter
"device":<string> //serial number of LEDbox
}
```
The parameters are:
- GENERAL
 - mode //modality of LEDbox ("master" or "slave")
 - ip_master //IP Address of master LEDbox (when mode=slave)
- WIFI
 - mode // modality of Wifi Connection ("ap" = Access Point; "client" = Wifi Client)
 - ssid // SSID of wireless network to connect the LEDbox (when mode=client)
 - psk // password of wireless network to connect the LEDbox (when mode=client)
- NETWORK
 - mode // modality of network card ("dhcp" or "static")
 - ip // IP address (when mode=static)
 - subnet // Subnet address (when mode=static)
 - gateway // IP gateway address (when mode=static)
 

# upload
Attribute of upload file
```json
{
    "filename": <string>, //filename
    "exist":<bool>, //only on response message check if the file already exist on the LEDbox
    "filepath":<string>, //path of local file
    "type": <enum(media,layout,upgrade)> //type of file to upload
 }
```

# playlist

Playlist parameters

```json
{

    "hashname": <string>, //unique identifier of playlist
    "title":<string>, //title of playlist
    "max_counter_time":<int>, //value in seconds; if value=0 the playlist will be run in loop; if value > 0 the playlist will be interrupt at end of timer
    "onfinish": <string>, //name of layout that will be show at the end of playlist;
    "items": [<file_playlist>] //list of files of playlist
}
```

# file_playlist

Parameter of file of the playlist

```json
{

    "filename": <string>, //filename to show (image JPG, PNG or GIF)
    "type":<int>, //0 = image; 1 = video
    "duration":<int> //seconds of duration image
}
```


# practice

Parameter of practice

```json
{

    "hashname": <string>, //unique identifier of practice
    "title":<string>, //title of practice
    "items": [<file_practice>] //list of files of practice
}
```

# file_practice

Parameter of file of the practice

```json
{

    "filename": <string>, //filename
    "type":<int>, //0 = image; 1 = video
    "rest":<int>, //seconds of duration of rest phase
    "work":<int>, //seconds of duration of work phase
    "soundrest":<enum(1,2,3,4,5,6)>, //sound to play after the end of rest phase
    "soundwork":<enum(1,2,3,4,5,6)>, //sound to play after the end of work phase
}
```