import socket
import os

HOST = "127.0.0.1"
PORT = 8080
hash = 242

flag = (os.environ.get('chall_flag', "cyberchaze{anotheronebitesthedust}")).encode()
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    while True:
        try:
            conn, addr = s.accept()
            with conn:
                print(f"Connected by {addr}")
                data = conn.recv(1)
                print(data[0])
                if data[0] == 254:
                    print("Correct")
                    print(flag)
                    conn.sendall(flag)
                conn.close()
        except Exception as e:
            print(e)
            continue