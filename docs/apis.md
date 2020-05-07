# Core APIs

# Info
Get main info of the LEDbox

<!--  tabs:start  -->

#### ** Request **

```json
{
"cmd": "Info",
"value":""
}
```

#### ** Response **

```json
{
"status":"ok",
"sender": "Info",
"value":
    {
        "deviceName": <string>, //serial number of the LEDbox,
        "version": <float>, //firmware version of the LEDbox,
    }
}
```
<!--  tabs:end  -->
### Example
<!--  tabs:start  -->
#### ** Request **

```json
{
"cmd": "Info",
"value":""
```
#### ** Response **
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
Initializate the connection of the LEDbox

<!--  tabs:start  -->

#### ** Request **

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

#### ** Response **

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
### Example
<!--  tabs:start  -->
#### ** Request **

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
#### ** Response **
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
Disconnect current client from the LEDbox
<!--  tabs:start  -->

### ** Request **

```json
{
"cmd": "Disconnect",
"value": ""
  
}
```

### ** Response **
```json
{
"sender": "Disconnect",
"value": ""
  
}
```

<!--  tabs:end  -->

# SetLayout
Load and show a layout file. The layout is loaded to the memory and if it's recalled it's review with all parameters already modified in previous.


<!--  tabs:start  -->
#### ** Request 1 **
Load to the memory -> Show on display
```json
{
"cmd": "SetLayout",
"value": <string> //layout name
}
```
#### ** Request 2 **
Load to the memory -> Edit values of sections -> Show on display
```json
{
"cmd": "SetLayout",
"name": <string>, //layout name 
"value":[<section>] //array of sections
}
```

### ** Response **
```json
{
"sender": "SetLayout",
"value":<string> //layout name
}
```

<!--  tabs:end  -->

### Example

<!--  tabs:start  -->
#### ** Request 1 **
Load to the memory -> Show on display
```json
{
"cmd": "SetLayout",
"value": "intro"
}
```
#### ** Request 2 **
Load to the memory -> Edit values of sections -> Show on display
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

### ** Response **
```json
{
"sender": "SetLayout",
"value":"intro"
}
```

<!--  tabs:end  -->

# ReloadLayout
Reload a layout

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "ReloadLayout",
"value": <string> //layout name,
}
```
### ** Response **
```json
{
"sender": "ReloadLayout",
"value":<string> //layout name
}
```
<!-- tabs:end -->

### Example
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "ReloadLayout",
"value": "intro"
}
```
### ** Response **
```json
{
"sender": "ReloadLayout",
"value":"intro"
}
```
<!-- tabs:end -->


# GetLayout
Get a current layout name
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "GetLayout",
"value": "",
}
```
### ** Response **
```json
{
"sender": "GetLayout",
"value":<string> //layout name
}
```
<!-- tabs:end -->
# SetSection
> Edit a section of current layout
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "SetSection",
"name": <string>, //section name,
"value": <attrib> or [<attrib>] //parameters of section (see attrib structure)
}
```
### ** Response **
```json
{
"sender": "SetSection",
"value": true
}
```
<!-- tabs:end -->

### Example

<!-- tabs:start -->
### ** Request **
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
### ** Response **
```json
{
"sender": "SetSection",
"value": true
}
```
<!-- tabs:end -->

# SetSections
Edit one or more sections of current layout
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "SetSections",
"value": [<section>] //array of sections
}
```
### ** Response **
```json
{
"sender": "SetSections",
"value": true
}
```
<!-- tabs:end -->
### Example
<!-- tabs:start -->
### ** Request **
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
### ** Response **
```json
{
"sender": "SetSections",
"value": true
}
```
<!-- tabs:end -->

# GetSection
Get section parameters of current layout
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "GetSection",
"name": <string> //section name
}
```
### ** Response **
```json
{
"sender": "GetSection",
"value": <section> // parameter of section
```
The attributes of sections are "text", "color" e "parameter" (only the section is "counter" type)

<!-- tabs:end -->

### Example

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "GetSection",
"name": "score1"
}
```
### ** Response **
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
Get all sections of current layout
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "GetSections"
}
```
### ** Response **
```json
{
"sender": "GetSections",
"value": [<section>]
}
```
<!-- tabs:end -->
# Horn
Play a sound
<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "Horn",
"value":<horn>
}
```
### ** Response **
```json
{
"sender": "Horn",
"value":true
}
```
<!-- tabs:end -->

# GetConfigs
Get all LEDbox config parameters

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "GetConfigs",
"value":""
}
```

### ** Response **

```json
{
"sender": "GetConfigs",
"value":[<config>]
}
```
<!-- tabs:end -->
# SetConfig
Set a LEDbox config parameter

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "SetConfig",
"value":<config> //parameter to setting
}
```

### ** Response **

```json
{
"sender": "SetConfig",
"value":true
}
```

<!-- tabs:end -->
### Example
<!-- tabs:start -->
### ** Request **
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

### ** Response **

```json
{
"sender": "SetConfig",
"value":true
}
```
<!-- tabs:end -->

# SetConfigs
Set one or more configs parameter of the LEDbox

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "SetConfigs",
"value":[<config>] 
}
```

### ** Response **

```json
{
"sender": "SetConfigs",
"value":true
}
```

<!-- tabs:end -->

# Reboot
Reboot LEDbox

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "Reboot",
"value":""
}
```

### ** Response **

```json
{
"sender": "Reboot",
"value":true
}
```

<!-- tabs:end -->

# Upload

Start a file uploading process

<!-- tabs:start -->
### ** Request **
```json
{
"cmd": "Upload",
"alias": <string>,
"sport": <string>,
"value": <upload>
}
```

### ** Response **

```json
{
    "status":"ok",
    "sender": "Upload",
    "value":<upload>
}
```

<!-- tabs:end -->

### Example

<!-- tabs:start -->
### ** Request **
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

### ** Response **

```json
{
    "status":"ok",
    "sender": "Upload",
    "value":{
        filename:"sponsor1.jpg",
        type:"media",
        exist:false
    }
}
```

<!-- tabs:end -->
