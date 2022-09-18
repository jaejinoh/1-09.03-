using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Socket을 열기위함
using System;
using System.Net;
using System.Net.Sockets;

public class Server : MonoBehaviour
{

    Socket server;

        
    void Start()
    {
        //Socket 세팅을 위한 설정
        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        //로컬서버 10000번 포트 연결
        server.Bind(new IPEndPoint(IPAddress.Any, 10000));

        //접속을 위해 버퍼 사이즈를 10으로 설정
        server.Listen(10);


        //Callback 함수 선언(비동기)
        server.BeginAccept(AcceptCallback, server);
        print("서버 실행");
    }



    void AcceptCallback(IAsyncResult result)
    {
        //클라이언트와 연결된 Socket
        Socket client = server.EndAccept(result);
        IPEndPoint addr = ((IPEndPoint)client.RemoteEndPoint);

        //Client의 정보도 가져옴
        print(string.Format("{0}, {1}", addr.ToString(), addr.Port.ToString()));
        
    }



    void Update()
    {
        
    }
}
