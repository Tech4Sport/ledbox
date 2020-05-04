# Custom Text
> Il plugin permette di visualizzare in background un testo sul display del LEDbox. Il testo può essere di diverse dimensioni, colori e anche animato.
# StartCustomText

> Avvia la riproduzione di un testo sul LEDbox
<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StartCustomText",
"value": {
        "hashname": <string>, //identificativo della sequenza
        "title": <string>, //titolo della sequenza
        "text": <string>, //testo da visualizzare
        "fontsize": <int>, //grandezza del testo
        "color": <(int,int,int)>, //colore del testo in rgb "r,g,b"
        "animation":<enum("","blinking","scroller_x_lr","scroller_x_rl", "scroller_y_tb","scroller_y_bt")>, //tipologia di animazione
        "animation_velocity":<enum(1,2,3,4,5)> //velocità della animazione
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StartCustomText",
"value": {
        "hashname": <string>, //identificativo della sequenza
        "title": <string> //titolo della sequenza
    }
}
```
<!--  tabs:end  -->

# PauseCustomText

> Mette in pausa la riproduzione di un testo (in caso di animazione in corso)

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "PauseCustomText",
"value": {
        "hashname": <string>, //identificativo della sequenza
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "PauseCustomText",
"value": {
        "hashname": <string>, //identificativo della sequenza
    }
}
```
<!--  tabs:end  -->

# StopCustomText

> Ferma la riproduzione del testo in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StopCustomText",
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StopCustomText",
"value": {
        "hashname": <string>, //identificativo della sequenza
        "title": <string>, //titolo della sequenza
    }
}
```
<!--  tabs:end  -->


# GetListPractice

> Restituisce l'elenco di tutte le sequenze di esercizi di un utente e uno sport caricate sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "GetListPractice",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "GetListPractice",
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

# UploadPractice

> Carica il file sequenza esercizi sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"UploadPractice",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "UploadPractice",
    "value":<upload>
}
```
<!--  tabs:end  -->

# DeleteAllPractice

> Elimina tutte le sequenze esercizi di un utente e uno sport sul LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
    "cmd":"DeleteAllPractice",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Risposta **

```json
{
    "status":"ok",
    "sender": "DeleteAllPractice",
    "value":true
}
```
<!--  tabs:end  -->