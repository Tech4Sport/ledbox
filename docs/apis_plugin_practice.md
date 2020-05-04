# Practice
> Il plugin permette di riprodurre in background una sequenza di esercizi (immagini/animazioni), ognuno diviso in due tempi: il tempo di preparazione (setup) e il tempo di esecuzione esercizio (work). Ogni tempo viene scandito da un suono emesso dal buzzer del LEDbox. 

# SetPractice

> Imposta i parametri della sequenza di esercizi

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "SetPractice",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": <practice> #parametri della sequenza
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "SetPractice",
"value": <practice>
}
```
<!--  tabs:end  -->

# StartPractice

> Avvia la riproduzione della sequenza esercizi nel LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StartPractice",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": {
        "hashname": <string>, #identificativo della sequenza
        "title": <string> #titolo della sequenza
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StartPractice",
"value": {
        "hashname": <string>, #identificativo della sequenza
        "title": <string> #titolo della sequenza
    }
}
```
<!--  tabs:end  -->

# PausePractice

> Mette in pausa la riproduzione della sequenza in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "PausePractice",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": {
        "hashname": <string>, #identificativo della sequenza
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "PausePractice",
"value": {
        "hashname": <string>, #identificativo della sequenza
    }
}
```
<!--  tabs:end  -->

# StopPractice

> Ferma la riproduzione della sequenza in corso

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "StopPractice",
"alias": <string>, #nome dell'utente
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "StopPractice",
"value": {
        "hashname": <string>, #identificativo della sequenza
        "title": <string> #titolo della sequenza
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