# Playlist Audio
> Il plugin permette di riprodurre in background una sequenza di file audio (MP3, WAV) sul LEDbox. La sequenza di audio viene  può essere riprodotta in loop infinito, oppure può interrompersi con un countdown. 

# SetPlaylistAudio

> Imposta i parametri della playlist da riprodurre

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "SetPlaylistAudio",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": <playlist> #parametri della playlist
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "SetPlaylistAudio",
"value": <playlist>
}
```
<!--  tabs:end  -->

# StartPlaylistAudio

> Avvia la riproduzione della playlist nel LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StartPlaylistAudio",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": {
        "hashname": <string>, #identificativo della playlist
        "title": <string> #titolo della playlist
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StartPlaylistAudio",
"value": {
        "hashname": <string>, #identificativo della playlist
        "title": <string> #titolo della playlist
    }
}
```
<!--  tabs:end  -->

# PausePlaylistAudio

> Mette in pausa la riproduzione della playlist in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "PausePlaylistAudio",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": {
        "hashname": <string>, #identificativo della 
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "PausePlaylistAudio",
"value": {
        "hashname": <string>, #identificativo della playlist
    }
}
```
<!--  tabs:end  -->

# StopPlaylistAudio

> Ferma la riproduzione della playlist in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StopPlaylistAudio",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StopPlaylistAudio",
"value": {
        "hashname": <string>, #identificativo della playlist
        "title": <string> #titolo della playlist
    }
}
```
<!--  tabs:end  -->


# GetListPlaylistAudio

> Restituisce l'elenco di tutte le playlist di un utente e uno sport caricate sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "GetListPlaylistAudio",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "GetListPlaylistAudio",
"value": {
        [{
            "hashname":<string>, //identificativo della playlist
            "title":<string>, //titolo della playlist
            "current_status":<int>, // identifica lo stato attuale della playlist (0 = non in riproduzione; 1 = in riproduzione; 2 = in pausa)
            "type": <int> //tipologia playlist (0 = immagini, 1 = video)
        }]
    }
}
```
<!--  tabs:end  -->

# UploadPlaylistAudio

> Carica il file playlist sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"UploadPlaylistAudio",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "UploadPlaylistAudio",
    "value":<upload>
}
```
<!--  tabs:end  -->

# DeleteAllPlaylistAudio

> Elimina tutte le playlist di un utente e uno sport sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"DeleteAllPlaylistAudio",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "DeleteAllPlaylistAudio",
    "value":true
}
```
<!--  tabs:end  -->