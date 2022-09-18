using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{

    Socket client;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("클라이언트 접속중");


            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //ip주소로 서버에 접속하도록 설정
            client.BeginConnect("127.0.0.1", 10000, null, client);

            //문자열을 변환
            //byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes("Hello");

            //client.Send(msg);
        }
    }
}
