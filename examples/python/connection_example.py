# -*- coding: utf-8 -*-

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
        datav["version2"]= 1.30
        datav["typeDevice"]= "app"
        data['value']=datav
        
        message=json.dumps(data) #serialize JSON
        message_to_send=CompressString(message)

        sock.send(message_to_send)
    except:
        print("Error Connection")
    