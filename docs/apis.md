# API

# Info
> Restituisce i dati del LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "Info",
"value":""
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "Info",
"value":
    {
        "deviceName": <string>, //numero seriale del LEDbox,
        "version": <float>, //versione del firmware del LEDbox,
    }
}
```
<!--  tabs:end  -->
### Esempio
<!--  tabs:start  -->
#### ** Richiesta **

```json
{
"cmd": "Info",
"value":""
```
#### ** Risposta **
```json
{
"status":"ok",
"sender": "Info",
"value":
    {
        "version": 0.50,
        "deviceName": "A0001",
    }
}
```
<!--  tabs:end  -->


# Init
> Inizializza la connessione al LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "Init",
"alias":<string>, //nome dell'utente
"sport": <string>, //nome dello sport selezionato
"value":
    {
        "version": <float>, //versione dell'api del client
        "typeDevice": <enum(app, center, ledbox)> //tipologia di client
    }
}
```

#### ** Risposta **

```json
{
"status":"ok",
"sender": "Init",
"value":
    {
        "deviceName": <string>, //numero seriale del LEDbox,
        "version": <float>, //versione del firmware del LEDbox,
        "role":<enum(admin,guest)>, //tipologia di ruole dell'utente,
        "current_layout":<string>, //layout che è visualizzato,
        "plugins":[<plugin>] //array dei plugin che sono installati sul LEDbox,
        }
}
```
<!--  tabs:end  -->
### Esempio
<!--  tabs:start  -->
#### ** Richiesta **

```json
{
"cmd": "Init",
"alias":"user1",
"sport": "volleyball",
"value":
    {
        "version": 1.30,
        "typeDevice": "app"
    }
}
```
#### ** Risposta **
```json
{
"status":"ok",
"sender": "Init",
"value":
    {
        "version": 0.50,
        "deviceName": "A0001",
        "role":"admin",
        "current_layout":"waiting",
        "plugins":[]
        }
}
```
<!--  tabs:end  -->

# Disconnect
> Disconnette il client dal LEDbox
<!--  tabs:start  -->

### ** Richiesta **

```json
{
"cmd": "Disconnect",
"value": ""
  
}
```

### ** Risposta **
```json
{
"sender": "Disconnect",
"value": ""
  
}
```

<!--  tabs:end  -->

# SetLayout
> Carica e visualizza sul LEDbox un layout. Il layout viene caricato in memoria e nel caso di richiamo viene rivisualizzato con tutti i parametri già in precedenza modificati


<!--  tabs:start  -->
#### ** Richiesta 1 **
Caricamento in memoria -> Visualizzazione sul LEDbox
```json
{
"cmd": "SetLayout",
"value": <string> //nome del layout
}
```
#### ** Richiesta 2 **
Caricamento in memoria -> Modifica dei valori delle sezioni -> Visualizzazione sul LEDbox
```json
{
"cmd": "SetLayout",
"name": <string>, //nome del layout 
"value":[<section>] //array delle sezioni da modificare
}
```

### ** Risposta **
```json
{
"sender": "SetLayout",
"value":<string> //nome del layout caricato
}
```

<!--  tabs:end  -->

### Esempio

<!--  tabs:start  -->
#### ** Richiesta 1 **
Caricamento in memoria -> Visualizzazione sul LEDbox
```json
{
"cmd": "SetLayout",
"value": "intro"
}
```
#### ** Richiesta 2 **
Caricamento in memoria -> Modifica dei valori delle sezioni -> Visualizzazione sul LEDbox
```json
{
"cmd": "SetLayout",
"name": "intro",
"value":[
    {
        "name":"serialNumber",
        "value":{
            "attrib":"text",
            "value":"A0002"
        }
    },
    {
        "name":"wifi",
        "value":{
            "attrib":"text",
            "value":"172.24.1.1"
        }
    },
    ]
}
```

### ** Risposta **
```json
{
"sender": "SetLayout",
"value":"intro"
}
```

<!--  tabs:end  -->

# ReloadLayout
> Ricarica un layout riaggiornandolo in quello presente in memoria (se già stato richiamato dal comando SetLayout)

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "ReloadLayout",
"value": <string> //nome del layout,
}
```
### ** Risposta **
```json
{
"sender": "ReloadLayout",
"value":<string> //nome del layout caricato
}
```
<!-- tabs:end -->

### Esempio
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "ReloadLayout",
"value": "intro"
}
```
### ** Risposta **
```json
{
"sender": "ReloadLayout",
"value":"intro"
}
```
<!-- tabs:end -->


# GetLayout
> Restituisce il nome del layout corrente
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "GetLayout",
"value": "",
}
```
### ** Risposta **
```json
{
"sender": "GetLayout",
"value":<string> //nome del layout caricato
}
```
<!-- tabs:end -->
# SetSection
> Modifica una sezione del layout corrente
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetSection",
"name": <string>, //nome della sezione da modificare,
"value": <attrib> //parametri della sezione
}
```
### ** Risposta **
```json
{
"sender": "SetSection",
"value": true
}
```
<!-- tabs:end -->

### Esempio

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetSection",
"name": "score1",
"value": {
    "attrib":"text",
    "value":"10"
    }
}
```
### ** Risposta **
```json
{
"sender": "SetSection",
"value": true
}
```
<!-- tabs:end -->

# SetSections
> Modifica una o più sezioni del layout corrente
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetSections",
"value": [<section>] //array in cui ogni elemento è una sezione da modificare
}
```
### ** Risposta **
```json
{
"sender": "SetSections",
"value": true
}
```
<!-- tabs:end -->
### Esempio
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetSections",
"value": [
        {
            "name":"score1",
            "value":[
                {
                    "attrib":"text",
                    "value":"10"
                },
                {
                    "attrib":"color",
                    "value":"120,200,2"
                }
            ]
        },
        {
            "name":"score2",
            "value":[
                {
                    "attrib":"text",
                    "value":"5"
                },
                {
                    "attrib":"color",
                    "value":"200,120,2"
                }
            ]
        }

    ]
}
```
### ** Risposta **
```json
{
"sender": "SetSections",
"value": true
}
```
<!-- tabs:end -->

# GetSection
> Restituisce i valori dei una sezione del layout corrente
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "GetSection",
"name": <string> //nome della sezione
}
```
### ** Risposta **
```json
{
"sender": "GetSection",
"value": <section> //parametri della sezione 
```
I parametri della sezione che vengono restituiti si riferiscono agli attributi text, color e parameter (solo se la sezione è di tipo "counter")

<!-- tabs:end -->

### Esempio

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "GetSection",
"name": "score1"
}
```
### ** Risposta **
```json
{
"sender": "GetSection",
"value": {
            "name":"score1",
            "value":[
                {
                    "attrib":"text",
                    "value":"11"
                },
                {
                    "attrib":"color",
                    "value":"120,200,2"
                },
            ]
        }
```
<!-- tabs:end -->

# GetSections
> Restituisce i valori di tutte le sezioni del layout corrente
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "GetSections"
}
```
### ** Risposta **
```json
{
"sender": "GetSections",
"value": [<section>] //array delle sezioni presenti nel layout
}
```
<!-- tabs:end -->
# Horn
> Fa emettere un suono al buzzer del LEDbox
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "Horn",
"value":<horn> //parametri della tipologia di suono
}
```
### ** Risposta **
```json
{
"sender": "Horn",
"value":true
}
```
<!-- tabs:end -->

# GetConfigs
> Restituisce tutti i parametri di configurazioni del LEDbox

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "GetConfigs",
"value":""
}
```

### ** Risposta **

```json
{
"sender": "GetConfigs",
"value":[<config>] // array con i parametri del LEDbox
}
```
<!-- tabs:end -->
# SetConfig
> Imposta un parametro del LEDbox

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetConfig",
"value":<config> // parametro da impostare
}
```

### ** Risposta **

```json
{
"sender": "SetConfig",
"value":true
}
```

<!-- tabs:end -->
### Esempio
<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetConfig",
"value":{
        "section":"GENERAL",
        "field":"ip_master",
        "value":"192.168.1.10"
    }
}
```

### ** Risposta **

```json
{
"sender": "SetConfig",
"value":true
}
```
<!-- tabs:end -->

# SetConfigs
> Imposta più parametri di configurazione del LEDbox

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "SetConfigs",
"value":[<config>] // array dei parametri da impostare
}
```

### ** Risposta **

```json
{
"sender": "SetConfigs",
"value":true
}
```

<!-- tabs:end -->

# Reboot
> Riavvia il LEDbox

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "Reboot",
"value":""
}
```

### ** Risposta **

```json
{
"sender": "Reboot",
"value":true
}
```

<!-- tabs:end -->

# Upload

> Inizia l'upload di un file layout all'interno del LEDbox.

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "Upload",
"alias": <string>,
"sport": <string>,
"value": <upload>
}
```

### ** Risposta **

```json
{
    "status":"ok",
    "sender": "Upload",
    "value":<upload>
}
```

<!-- tabs:end -->

## Esempio

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": "Upload",
"alias": "user1",
"sport": "volleyball",
"value": {
    filename:"sponsor1.jpg",
    filepath:"c:\sponsors\sponsor1.jpg",
    type:"media"
    }
}
```

### ** Risposta **

```json
{
    "status":"ok",
    "sender": "Upload",
    "value":{
        filename:"sponsor1.jpg",
        filepath:"c:\sponsors\sponsor1.jpg",
        type:"media",
        exist:false
    }
}
```

<!-- tabs:end -->
