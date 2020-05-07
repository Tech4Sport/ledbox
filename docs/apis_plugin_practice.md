# Practice
> The plugin will be plays, in background mode, a exercises sequence on LEDbox. Every practice is divided in two parts: the setup time and the rest time. At the end of both phases, will be play a sound from buzzer. 

# SetPractice

> Set parameters of practice

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "SetPractice",
"alias": <string>, //username
"sport": <string>, //sport selected
"value": <practice> //parameters of practice
}
```

#### ** Response **

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

> Set the current practice in pause

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "PausePractice",
"alias": <string>,
"sport": <string>,
"value": {
        "hashname": <string>, //id of practice
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "PausePractice",
"value": {
        "hashname": <string>
    }
}
```
<!--  tabs:end  -->

# StopPractice

> Stop the current practice and show a "waiting" layout

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "StopPractice",
"alias": <string>, 
"sport": <string>, #nome dello sport selezionato
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "StopPractice",
"value": {
        "hashname": <string>,
        "title": <string>
    }
}
```
<!--  tabs:end  -->


# GetListPractice

> Get a list of all practices contains on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "GetListPractice",
"alias": <string>,
"sport": <string>,
"value": ""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "GetListPractice",
"value": {
        [{
            "hashname":<string>,
            "title":<string>,
            "current_status":<int>, // status of practice (0 = non playing; 1 = playing; 2 = in pause)
            
        }]
    }
}
```
<!--  tabs:end  -->

# UploadPractice

> Upload a practice file on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"UploadPractice",
    "alias": <string>,
    "sport": <string>,
    "value": <upload>
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "UploadPractice",
    "value":<upload>
}
```
<!--  tabs:end  -->

# DeleteAllPractice

> Delete all practices of a username and sport on LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
    "cmd":"DeleteAllPractice",
    "alias": <string>,
    "sport": <string>,
    "value": ""
}
```

#### ** Response **

```json
{
    "status":"ok",
    "sender": "DeleteAllPractice",
    "value":true
}
```
<!--  tabs:end  -->