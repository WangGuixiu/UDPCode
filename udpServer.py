import socket


def main():
    addr = ("127.0.0.1", 8898)
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    s.bind(addr)
    #s.listen(128)
    #sd,sa = s.accept()
    while True:
        sd, sa = s.recvfrom(1024)
        print(sd, sa)
    s.close()


if __name__ == "__main__":
    main()
