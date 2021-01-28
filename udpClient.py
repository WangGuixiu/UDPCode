import socket


def main():    
    addr = ("127.0.0.1", 8888)
    sc = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    #sc.connect(addr)
    #sc.send("hello".encode())
    #data = sc.recv(1024)
    data = "udpData".encode()
    sc.sendto(data, addr)
    print(data.decode())
    sc.close()


if __name__ == "__main__":
    main()
