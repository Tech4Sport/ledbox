# Struttura dei messaggi API

> I messaggi API sono in formato JSON e seguono la seguente strutturazione:

Richiesta
```json
{
"cmd": <metodo da richiamare>,
"value": <parametri del metodo>
}
```

Risposta corretta
```json
{
"status": "Ok",
“sender” : <metodo richiamato>,
“value”: <valori restituiti dal metodo>
}
```
Risposta di errore

```json
{
"status": "Error",
“sender” : <metodo richiamato>,
“error_code”:<codice errore>,
“message”: <messaggio errore errore>,
}
```

# New

> test