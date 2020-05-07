# Introduction
The LEDbox is a display system on RGB LED matrix LED. Each rendered screen belongs to a "layout", an XML file in which are specified for each area of the screen (defined "section") their functions and characteristics: for each "section" you can specify whether to display a textual content, a shape or an image. Below is an example of a layout file:
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

This file show to screen of LEDbox this image:

![Example Layout](/images/example_layout.png)

On LEDBox it's possible load more layout files. Every layout file can be uploaded by API's commands, as well as every "section" can be modified by API: in this way the LEDbox can adapt to all sporting and non-sporting needs
For use APIs it's first necessary connect the LEDbox.

# Connections

The LEDbox architectures its based by request/response messagging over every communication protocols avaible on LEDbox as Ethernet/Wifi/Bluetooth/USB Serial.

For start the communication it's first necessary the connection to device over a protocol and after send a message (described in API section of this documentation). 

For TCP/IP communication its possible:
* connect the LEDbox (over LAN or Wifi) to a existing network: in this way it's assigned an IP address to LEDbox
* connect the software client to hotspot network of the LEDbox: in this way the LEDbox will have default IP address __172.24.1.1__

For both the TCP port of the LEDbox is __8889___.
To below an example for TCP/IP connection to LEDbox:

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

For Bluetooth communication, the client device must be pared to the LEDbox: the pairing process it's possible only on first minute of start of the LEDbox.


<!-- tabs:start -->
### ** Python **
```python
import bluetooth
import threading

mac_address="00:12:D2:5A:BD:E4" #Bluetooth MAC Address of LEDbox
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

For Serial USB communication it's neccessary setting the connection with this parameters:

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

# Sending and receiving

The APIs are in JSON format (https://www.json.org) with the this structure:

<!-- tabs:start -->
### ** Request **
```json
{
"cmd":<string>, //method to call,
"value": <...> //parameters of method
}
```

### ** Correct response **
```json
{
"status": "Ok",
"sender" : <string>, //method called,
"value": <...> // values of method called
}
```
### ** Error response **

```json
{
"status": "Error",
"sender" : <string>, // method called,
"error_code":<int>, // code error,
"message":<string> // description of error
}
```
<!-- tabs:end -->

The JSON message are sending as UTF-8 string compressed in GZip (https://www.gzip.org/). On below some script for coding the message:

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
> For receiving the messages first these must decompress and after these must parsing in JSON. On below some script for decoding the message: 


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
# Uploading a file

For process to uploading a file on LEDbox this occurs differently if the connection is TCP/IP, Bluetooth or Serial USB:

* For TCP/IP, the LEDbox receive a file over socket on TCP port __12345__
* For Bluetooth, the LEDbox receive a file over socket with UUID 00001101-0000-1000-8000-00805F9B34FC (LEDBoxUpload)
* For Serial USB, the LEDbox receive a file on the same serial port to which the connection is open.

For sending a file you need:

1. Send a API message "Upload" for start a uploading process
2. When you receive a confirm message, you can start send a file as a stream bytes.
3. On finish on sending, the LEDbox response with a message "Uploaded" to confirm that upload is completed.

If the file is a ZIP format, after receiving the LEDbox automatically performs the decompression.

# Example
For estabilishing a communication with the LEDbox, you must send a "Init" message as the example below:

<!-- tabs:start -->
### ** Python **
```python

import socket
import threading
from io import BytesIO
import gzip
import json

host="192.168.1.7" #IP address of LEDbox
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



