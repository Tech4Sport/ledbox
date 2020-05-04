# Playlist Images
> Il plugin permette di riprodurre in background una sequenza di immagini (JPG, PNG, GIF e GIF animate) sul LEDbox. La sequenza di immagini può essere riprodotta in loop infinito, oppure può interrompersi con un countdown. 

# SetPlaylistImage

> Imposta i parametri della playlist (sequenza di immagini) da visualizzare

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "SetPlaylistImage",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": <playlist> #parametri della playlist
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "SetPlaylistImage",
"value": <playlist>
}
```
<!--  tabs:end  -->

# StartPlaylistImage

> Avvia la riproduzione della playlist nel LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StartPlaylistImage",
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
"sender": "StartPlaylistImage",
"value": {
        "hashname": <string>, #identificativo della playlist
        "title": <string> #titolo della playlist
    }
}
```
<!--  tabs:end  -->

# PausePlaylistImage

> Mette in pausa la riproduzione della playlist in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "PausePlaylistImage",
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
"sender": "PausePlaylistImage",
"value": {
        "hashname": <string>, #identificativo della playlist
    }
}
```
<!--  tabs:end  -->

# StopPlaylistImage

> Ferma la riproduzione della playlist in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StopPlaylistImage",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StopPlaylistImage",
"value": {
        "hashname": <string>, #identificativo della playlist
        "title": <string> #titolo della playlist
    }
}
```
<!--  tabs:end  -->


# GetListPlaylistImage

> Restituisce l'elenco di tutte le playlist di un utente e uno sport caricate sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "GetListPlaylistImage",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "GetListPlaylistImage",
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

# UploadPlaylistImage

> Carica il file playlist sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"UploadPlaylistImage",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "UploadPlaylistImage",
    "value":<upload>
}
```
<!--  tabs:end  -->

# DeleteAllPlaylistImage

> Elimina tutte le playlist di un utente e uno sport sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"DeleteAllPlaylistImage",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "DeleteAllPlaylistImage",
    "value":true
}
```
<!--  tabs:end  -->