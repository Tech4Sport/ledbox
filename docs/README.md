# Introduzione
Il LEDbox è un sistema di visualizzazione su schermi LED matrix RGB. Ogni schermata renderizzata appartiene ad un "layout", un file XML nel quale sono specificate le funzioni e caratteristiche di ogni area dello schermo (definita "section"): per ognuna di questa si può specificare se visualizzare un contenuto testuale, una forma o un'immagine. Di seguito un esempio di file layout:
```xml
<?xml version="1.0"?>
<layout name="volleyball_matchscore_02">
	<section type="text" name="team1" x="0" y="-3" fontsize="18" color="0,0,255" align="left">TEAM A</section>	
	<section type="rectangle" private="true" name="bg_score1" x="0" y="17" width="64" height="46" bordercolor="0,0,255"></section>
	<section type="text" name="score1" x="32" y="10" fontsize="55" color="0,0,255" align="center">0</section>
	<section type="text" name="set1" x="91" y="-5" fontsize="26" color="0,0,255" align="right">0</section>	
	<section type="text" name="vs" x="97" y="-1" fontsize="18" color="255,255,255" align="center">-</section>
	<section type="text" name="set2" x="102" y="-5"  fontsize="26" color="255,69,0" align="left">0</section>
	<section type="text" name="timeout1" x="73" y="23" fontsize="18" color="white" align="left">0</section>
	<section type="text" private="true" name="lbl_to" x="96" y="26" fontsize="14" color="white" align="center">T</section>
	<section type="text" name="timeout2" x="120" y="23" fontsize="18" color="white" align="right">0</section>
	<section type="text" name="sub1" x="73" y="41" fontsize="18" color="white" align="left">0</section>	
	<section type="text" private="true" name="lbl_sub" x="96" y="43" fontsize="14" color="white" align="center">S</section>	
	<section type="text" name="sub2" x="120" y="41" fontsize="18" color="white" align="right">0</section>
	<section type="rectangle" name="serve1" x="70" y="60" src="" width="16" height="5" color="0,0,0"></section>
	<section type="rectangle" name="serve2" x="107" y="60" src="" width="16" height="5" color="0,0,0"></section>
	<section type="text" name="team2" x="192" y="-3" fontsize="18" color="255,69,0" align="right">TEAM B</section>	
	<section type="rectangle" private="true" name="bg_score2" x="127" y="17" width="64" height="46" bordercolor="255,69,0"></section>
	<section type="text" name="score2" x="160" y="10" fontsize="55" color="255,69,0" align="center">0</section>
</layout>
```

Questo file renderizza sullo schermo del LEDbox questa immagine:

![Example Layout](/images/example_layout.png)

Sul LEDbox è possibile caricare più file layout che possono eseguire renderizzazioni differenti. Ogni file layout può essere caricato dinamicamente tramite i comandi API (descritti nel proseguio) così come ogni section presente può essere modificata con le API: in questo modo il LEDbox può adattarsi a tutte le esigenze sportive e non.

Per poter utilizzare le API è neccessario dapprima effettuare una connessione al LEDbox.


# Connessione

L'architettura di comunicazione del LEDbox è basato su messaggistica request/response veicolato su tutti i protocolli di comunicazione disponibili sul LEDbox come Ethernet/Wifi/Bluetooth/USB Serial.

Per avviare la comunicazione è necessario effettuare prima la connessione al dispositivo secondo un protocollo, e poi inviare i diversi messaggi (descritti nella sezione API). 

Per le comunicazioni TCP/IP è possibile:
* Connettere il LEDbox (in LAN o Wifi) ad una rete esistente: in questo caso al LEDbox verrà assegnato un indirizzo IP al quale connettersi
* Connettere il software client direttamente alla rete hotspot del LEDbox: in questo caso il LEDbox avrà l'indirizzo IP di default __172.24.1.1__

Per entrambe le tipologie la porta di comunicazione TCP del LEDbox è la __8889__.
Di seguito l'esempio di connessione TCP/IP al LEDbox:

<!-- tabs:start -->
### ** Python **
```python
import socket
import threading

host="172.24.1.1"
port=8889

def onMessageReceived(sock)
    while True:
        try:
            data = sock.recv(2048)
            if(len(data)>0):
                message_bytes=bytearray(data)
                print(message_bytes)
                # ... your code for decode and process message 

        except Exception, e:
            print ("Error listener "+str(e))

if __name__ == "__main__":
    
    sock=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    try:
        sock.connect((host,port))
        print("Connection established")
        threading.Thread(target = onMessageReceived,args = (sock,)).start()
     except:
        print("Error Connection")
``` 

### ** C# **

```csharp
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class APILEDbox
    {
        Socket socket;
        Thread listen;
        public event EventHandler<JObject> EventMessageReceived;

        public APILEDbox()
        {
        }

        public bool connect(string ip)
        {

            IPAddress host = IPAddress.Parse(ip);
            int port = 8889;

            socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(host, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(2000, true);

            if (socket.Connected)
            {
                Console.WriteLine("Connection established");
                //start listener
                listen = new Thread(onMessageReceived);
                listen.Name = "TCP Listener";
                listen.Start();
                return true;
            }
            else
            {
                Console.WriteLine("Connection Error");
                return false;
            }
        }

        void onMessageReceived()
        {
            byte[] bytes = new byte[2048];
            while (true)
            {
                try
                {

                    int bytesRec = socket.Receive(bytes)Console.write(bytes)
                    // ... your code for decode and process message
                }
                catch
                {
                    Console.WriteLine("connection broken");
                    continue;
                }

            }
        }

        


        

       

        

    }
```

### ** Node.js **
```javascript
const net = require('net');

var host="172.24.1.1"
var port=8889

function connect(onconnect,onerror){
        
    var socket=new net.Socket();
    socket.setTimeout(2000);

    // set events
    socket.on('error',(data)=>{
        onerror();
    });

    socket.on('data', (data) => {
        console.log(data);
        // ... your code for decode and process message 
    });

    socket.on('end', () => {
        console.log('disconnected from server');
    });

    socket.on('timeout', () => {
        console.log('socket timeout');
        socket.end();
        onerror();
    });

    // execute connection

    socket.connect({host:host, port:port},  () => {
        console.log('Connection established');
        onconnect(true);
    });
        
}


```

<!-- tabs:end -->



Per la comunicazione Bluetooth bisogna effettuare il paring del dispositivo client al LEDbox: il processo di accoppiamento è possibile solo nel primo minuto di attività del LEDbox.

<!-- tabs:start -->
### ** Python **
```python
import bluetooth
import threading

mac_address="00:12:D2:5A:BD:E4"
port=1

def onMessageReceived(sock)
    while True:
        try:
            data = sock.recv(1024)
            if(len(data)>0):
                message_bytes=bytearray(data)
                print(message_bytes)
                # ... your code for decode and process message 

        except Exception, e:
            print ("Error listener "+str(e))

if __name__ == "__main__":
    uuid="00001101-0000-1000-8000-00805F9B34FB"
    
    sock=bluetooth.BluetoothSocket(bluetooth.RFCOMM )
    sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    if (sock.connect((mac_address,port))):
        print("Connection established")
        threading.Thread(target = onMessageReceived,args = (sock)).start()
    else:
        print("Connection Error")
```

<!-- tabs:end -->


Per la comunicazione Serial USB è necessario impostare una connessione seriale con i seguenti parametri:
* Baud Rate: 38400
* Parity: None
* Bit : 8

<!-- tabs:start -->
### ** Python **
```python
import serial
import threading

def onMessageReceived(ser):
    eol=b'\r\n'
    leneol=len(eol)

    while True:
        try:
            c= ser.read(1)
            if c:
                data +=c
                if(data[-leneol:] == eol):
                    # ... your code for decode and process message 
                    data=bytearray() #reset variable
            else:
                if(len(data)>0):
                    # ... your code for decode and process message 

                    data=bytearray() #reset variable

if __name__ == "__main__":

    ser=serial.Serial("/dev/ttyUSB1",timeout=0.05)
    ser.baudrate= 38400

    threading.Thread(target = onMessageReceived,args = (ser)).start()

```

### ** Node.js **
```javascript
var SerialPort = require('serialport')
const Readline = require('@serialport/parser-readline')

var serial= new SerialPort("/dev/ttyUSB1", {
            baudRate: 38400,
            autoOpen: true
});

function connect(onconnect,onerror){
    serial.on('open', function () {
        console.log('Serial Port is on!')
        this.flush((error) => {
            console.log("port flushed")       
        });
        onconnect(true);
    })

    var endofline='\n<<EOF>>\n';
    
    const parser = this.serial.pipe(new Readline({ delimiter: endofline, encoding:'binary' }))
    parser.on('data', function(data){
        
        // ... your code for decode and process message 
            
    });

}

connect((onconnect)=>{
    //...after connection
},
(onerror)=>{
    //...when connection error
});
```



<!-- tabs:end -->

# Invio e ricezione

> I messaggi API sono in formato JSON (https://www.json.org) e seguono la seguente strutturazione:

<!-- tabs:start -->
### ** Richiesta **
```json
{
"cmd": <metodo da richiamare>,
"value": <parametri del metodo>
}
```

### ** Risposta corretta **
```json
{
"status": "Ok",
"sender" : <metodo richiamato>,
"value": <valori restituiti dal metodo>
}
```
### ** Risposta di errore **

```json
{
"status": "Error",
"sender" : <metodo richiamato>,
"error_code":<codice errore>,
"message": <messaggio errore errore>,
}
```
<!-- tabs:end -->

>I messaggi JSON vengono inviati sottoforma di stringhe codificate in UTF-8 e a sua volta compresse in GZip (https://www.gzip.org/). Di seguito vengono riportate alcuni codici di per la codifica dei messaggi:

<!-- tabs:start -->
### ** Python **
```python
from io import BytesIO
import gzip
import json

def CompressString(message):
    out=BytesIO()
    with gzip.GzipFile(fileobj=out,mode="wb") as gz:
        message = message.encode('utf-8')
        gz.write(message)
        gz.close()

    #send message
    message_to_send=out.getvalue()
    
    return message_to_send

#create info message
data={}
data['cmd']="Info"
data['value']=""

message=json.dump(data) #serialize JSON

message_to_send=CompressString(message)

#... your code for send message to LEDbox



```

### ** C# **
```csharp
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class APILEDbox

    public struct message
    {
        public string cmd;
        public string value;
    };


    private byte[] CompressString(string message)
    {

        var bytes = Encoding.Default.GetBytes(message);

        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
            {
                CopyTo(msi, gs);
            }

            return mso.ToArray();
        }
    }

    public void sendInfoMessage(){
        message data=new message();
        data.cmd="Info";
        data.value="";

        string message = JsonConvert.SerializeObject(m); //serialize JSON

        string message_to_send=CompressString(message);
        //... your code for send message to LEDbox

    }

}


```

### ** Node.js **
```javascript
var zlib = require('zlib');

function CompressString(message){
    var compress=zlib.gzipSync(message);
    return compress; 
}

//create info message
var data={}
data.cmd="Info"
data.value=""

var message=JSON.stringify(data); //serialize JSON

var message_to_send=CompressString(message)

//... your code for send message to LEDbox

```
<!-- tabs:end -->

> Per la ricezione dei messaggi questi devono essere dapprima decompressi e poi parserizzati in JSON. Di seguito vengono riportate alcuni codici di per la decodifica dei messaggi:

<!-- tabs:start -->
### ** Python **
```python
import cStringIO
import gzip
import json

def DecompressString(message):
    buff=cStringIO.StringIO(message)
    with gzip.GzipFile(fileobj=buff) as gz:
        message=gz.read()
        message.decode("utf-8")
    
    data=json.loads(message)

    return data
```

### ** C# **
```csharp
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public JObject DecompressString(byte[] message)
{

    using (var msi = new MemoryStream(message))
    using (var mso = new MemoryStream())
    {
        using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress))
        {
            //gs.CopyTo(mso);
            CopyTo(gs, mso);
        }

        string result= Encoding.ASCII.GetString(mso.ToArray());
        JObject jo = JsonConvert.DeserializeObject<JObject>(result);

        return jo;
    }
}
```

### ** Node.js **
```javascript
var zlib = require('zlib');
function DecompressString(message){
    var uncompress=zlib.gunzipSync(message);
    var data=JSON.parse(uncompress);
    return data; 
}

```
<!-- tabs:end -->
# Upload

Il processo di upload di un file sul LEDbox avviene differentemente se la connessione è TCP/IP, Bluetooth o USB serial. In particolare:

* Nel caso di TCP/IP il LEDbox riceve file su un socket TCP sulla porta 12345
* Nel caso di Bluetooth il LEDbox riceve file su un socket con UUID 00001101-0000-1000-8000-00805F9B34FC (LEDBoxUpload)
* Nel caso di USB Serial il LEDbox riceve file sulla stessa porta seriale a cui è aperta la connessione.

Per le prime due è possibile inviare un file al LEDbox e parallelamente inviare altri messaggi, mentre per l'ultima non è possibile procedere all'invio di un messaggio fino a quando l'upload non è completato.

Per l'invio di un file bisogna:

1. Inviare il messaggio di API "Upload" che indica che verrà inviato un file
2. Alla ricezione di conferma che il messaggio API è stato ricevuto, iniziare l'invio del file sottoforma di stream di byte
3. Al termine dell'invio si riceve dal LEDbox il messaggio "Uploaded" che indica che l'upload è stato completato.

Se il file inviato è in formato ZIP, il LEDbox dopo la ricezione provvede automaticamente ad effettuare la decompressione nella cartella in cui è stato caricato.

# Esempio

Per avviare una comunicazione con il LEDbox, bisogna inviare il messaggio "Init" come dall'esempio riportato di seguito:

<!-- tabs:start -->
### ** Python **
Esempio di connessione TCP/IP con l'hotspot del LEDbox
```python

import socket
import threading
from io import BytesIO
import gzip
import json

host="192.168.1.7"
port=8889

def CompressString(message):
    out=BytesIO()
    with gzip.GzipFile(fileobj=out,mode="wb") as gz:
        message = message.encode('utf-8')
        gz.write(message)
        gz.close()

    #send message
    message_to_send=out.getvalue()
    
    return message_to_send

def DecompressString(message):
    buff=BytesIO(message)
    with gzip.GzipFile(fileobj=buff) as gz:
        message=gz.read()
        message.decode("utf-8")

    data=json.loads(message)

    return data


def onMessageReceived(sock):
    while True:
        try:
            data = sock.recv(2048)
            if(len(data)>0):
                message_bytes=bytearray(data)
                processMessage(DecompressString(message_bytes))
        except Exception:
            print ("Error listener")


def processMessage(data):
    print(data)
    # .. your code to process the message request

if __name__ == "__main__":
    
    sock=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    try:
        sock.connect((host,port))
        
        print("Connection established")
        threading.Thread(target = onMessageReceived,args = (sock,)).start()
        
        
        #send init message
        
        data={}
        data['cmd']="Init"
        data["alias"]="user1"
        data["sport"]= "volleyball"
        datav={}
        datav["version"]= 1.30
        datav["typeDevice"]= "app"
        data['value']=datav
        
        message=json.dumps(data) #serialize JSON
        message_to_send=CompressString(message)

        sock.send(message_to_send)
    except:
        print("Error Connection")

```
### ** C# **
```csharp
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class APILEDbox
    {
        Socket socket;
        Thread listen;
        public event EventHandler<JObject> EventMessageReceived;

        public APILEDbox()
        {
        }

        public bool connect(string ip)
        {

            IPAddress host = IPAddress.Parse(ip);
            int port = 8889;

            socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(host, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(2000, true);

            if (socket.Connected)
            {
                Console.WriteLine("Connection established");
                //start listener
                listen = new Thread(onMessageReceived);
                listen.Name = "TCP Listener";
                listen.Start();

                JObject message = new JObject();
                message["cmd"] = "Init";
                message["alias"]="user1"
                message["sport"]= "volleyball"
                JObject value = new JObject();
                value["version"]= 1.30
                value["typeDevice"]= "app"
                message["value"] = value;

                SendMessage(message);

                return true;
            }
            else
            {
                Console.WriteLine("Connection Error");
                return false;
            }
        }

        void onMessageReceived()
        {
            byte[] bytes = new byte[2048];
            while (true)
            {
                try
                {

                    int bytesRec = socket.Receive(bytes);
                    JObject data = DecompressString(bytes);
                    if(EventMessageReceived!=null)
                        EventMessageReceived(this, data);
                    ProcessMessage(data);

                }
                catch
                {
                    Console.WriteLine("connection broken");
                    continue;
                }

            }
        }

        public void SendMessage (JObject data)
        {
            string message = JsonConvert.SerializeObject(data);
            socket.Send(CompressString(message));

        }


        void ProcessMessage(JObject data)
        {
            Console.Write(data.ToString());
            // .. your code to process the message request

        }

        byte[] CompressString(string message)
        {

            var bytes = Encoding.Default.GetBytes(message);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }

                return mso.ToArray();
            }
        }

        JObject DecompressString(byte[] message)
        {

            using (var msi = new MemoryStream(message))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }

                string result = Encoding.ASCII.GetString(mso.ToArray());
                JObject jo = JsonConvert.DeserializeObject<JObject>(result);

                return jo;
            }
        }

    }

```


<!-- tabs:end -->



