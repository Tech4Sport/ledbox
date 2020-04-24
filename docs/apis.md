# API

# Init
> Inizializza la connessione al LEDbox

<!--  tabs:start  -->

#### ** Richiesta **

```json
{
"cmd": "Init",
"value":
    {
        "alias":<string>, //nome dell'utente
        "version": <float>, //versione dell'api del client
        "sport": <string>, //nome dello sport selezionato
        "typeDevice": <enum(app, center, ledbox)> //tipologia di client
    }
}
```

#### ** Risposta **

```json
{
"sender": "Init",
"value":
    {
        "alias":<string>, //nome dell'utente,
        "version": <float>, //versione del firmware del LEDbox,
        "sport": <string>, //nome dello sport selezionato,
        "deviceName": <string>, //numero seriale del LEDbox,
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
"value":
    {
        "alias":"user1",
        "version": 1.30,
        "sport": "volleyball",
        "typeDevice": "app"
        }
    
}
```
#### ** Risposta **
```json
{
"sender": "Init",
"value":
    {
        "alias":"user1",
        "version": 0.50,
        "sport": "volleyball",
        "deviceName": "A0001",
        "role":"admin",
        "current_layout":"waiting",
        "plugins":[
            {}
            ]
        }
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

## Richiesta
```json
{
"cmd": "GetLayout",
"value": "",
}
```
## Risposta
```json
{
"sender": "GetLayout",
"value":<string> #nome del layout caricato
}
```
# SetSection
> Modifica una sezione del layout corrente

## Richiesta
```json
{
"cmd": "SetSection",
"name": <string> #nome della sezione da modificare,
"value": {
    "attrib":<string> #tipologia di attributo da modificare della sezione (vedi struttura layout),
    "value":<string> #valore da modificare
    }
}
```
## Risposta
```json
{
"sender": "SetSection",
"name": <string> #nome della sezione modificata,
"value": true
}
```

# SetSections
> Modifica una o più sezioni del layout corrente

## Richiesta
```json
{
"cmd": "SetSections",
"value": [<section>] #array in cui ogni elemento è una sezione da modificare
}
```
## Risposta
```json
{
"sender": "SetSections",
"value": true
}
```

# GetSection
> Restituisce i valori dei una sezione del layout corrente

## Richiesta
```json
{
"cmd": "GetSection",
"name": <string> #nome della sezione
}
```
## Risposta
```json
{
"sender": "GetSection",
"value": <section> #parametri della sezione 
```
> I parametri della sezione che vengono restituiti si riferiscono agli attributi text, color e parameter (solo se la sezione è di tipo "counter")
# GetSections
> Restituisce i valori di tutte le sezioni del layout corrente

## Richiesta
```json
{
"cmd": "GetSections"
}
```
## Risposta
```json
{
"sender": "GetSections",
"value": [<section>] #array delle sezioni presenti nel layout
}
```

# Horn
> Fa emettere un suono al buzzer del LEDbox

## Richiesta
```json
{
"cmd": "Horn",
"value":<horn> #parametri della tipologia di suono
}
```
## Risposta
```json
{
"sender": "Horn",
"value":true
}
```
