# Tipi di dati

# section
> Identifica la sezione del layout

```json
{
"name": <string>, //nome della sezione,
"value":[<attrib>] //array degli attributi della sezione
}
```

# attrib
> Attributi della sezione

```json
{
"attrib": <string>, //nome dell'attributo,
"value":<string> //valore dell'attributo
}
```

# horn
> Attributi per modulare il suono del buzzer
```json
{
"times": <int>, //numero di suoni da riprodurre,
"sleep":<int> //valore in millisecondi che indica la pausa di un suono e l'altro
}
```

# config
> Parametro di configurazione del LEDbox
```json
{
"section": <int>, //sezione di appartenza del parametro
"field":<int>, //nome del parametro
"value":<string> //valore del parametro
}
```

# upload
> Parametri per effettuare l'upload di un file sul LEDbox
```json
{
"filename": <string>, //nome del file da caricare
"exist":<bool>, //indica se il file è già esistente sul LEDbox
"filepath":<string>, //path del file locale (necessario per ottenerlo nel messaggio di risposta)
"type": <enum(media,layout,upgrade)> //tipologia di file da caricare
 }
```

# playlist

> Parametri di una playlist

```json
{

    "hashname": <string>, //identificativo del file
    "title":<string>, //titolo della playlist
    "max_counter_time":<int>, //valore in secondi; se 0 la playlist viene eseguita in loop; se > 0 la playlist si interrempe al termine del counter
    "onfinish": <string>, //indica quale layout deve essere aperto quando la playlist termina
    "items": [<file_playlist>] //elenco dei file da eseguire nella playlist
}
```

# file_playlist

> Parametri di una playlist

```json
{

    "filename": <string>, //nome del file
    "type":<int>, //0 = immagine; 1 = video
    "duration":<int> //secondi di permanenza dell'immagine
}
```


# practice

> Parametri di una sequenza esercizi

```json
{

    "hashname": <string>, //identificativo del file
    "title":<string>, //titolo della sequenza
    "items": [<file_practice>] //elenco dei file da eseguire
}
```

# file_practice

> Parametri di un file per la sequenza esercizi

```json
{

    "filename": <string>, //nome del file
    "type":<int>, //0 = immagine; 1 = video
    "rest":<int>, //secondi di permanenza della fase di setup
    "work":<int>, //secondi di permanenza della fase di esecuzione di esercizi
    "soundrest":<enum(1,2,3,4,5,6)>, //tipologia di suono da emettere alla fine della fase setup
    "soundwork":<enum(1,2,3,4,5,6)>, //tipologia di suono da emettere alla fine della fase rest
}
```