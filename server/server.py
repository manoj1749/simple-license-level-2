import socket
import os
import base64

HOST = "127.0.0.1"
PORT = 8080
hash = 242

flag = (os.environ.get('chall_flag', "cyberchaze{1s_th1s_4_r3al_l1c3ns3}")).encode()
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    while True:
        try:
            conn, addr = s.accept()
            with conn:
                print(f"Connected by {addr}")
                data = conn.recv(2048)
                encData=data.decode("utf-8")
                count = 0
                for i in data:
                    count += 1
                if count == 10:
                    license = encData[0:10]
                    print(license)
                    base64_string ="MTA4MjExMTQwOQ=="
                    base64_bytes = base64_string.encode("ascii")
                    string_bytes = base64.b64decode(base64_bytes)
                    string = string_bytes.decode("ascii")
                    print(string)
                    if license == string:
                        conn.sendall(flag)
                    else:
                        conn.sendall(b"Invalid License Key")
                else:
                    conn.sendall(b"Length of string is not as expected")
                conn.close()
        except Exception as e:
            print(e)
            continue