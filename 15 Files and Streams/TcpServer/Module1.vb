Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Module Module1

   ' The server application
   Sub Main()
      ' Listen to port 2048.
      Dim localhostAddress As IPAddress = IPAddress.Loopback
      Dim tcpList As New TcpListener(localhostAddress, 2048)
      tcpList.Start()

      Do
         ' Wait for the next client to make a request.
         Console.WriteLine("Waiting for data from clients...")
         Dim tcpCli As TcpClient = tcpList.AcceptTcpClient()
         ' Read data sent by the client (a CR-LF separated string in this case). 
         Dim ns As NetworkStream = tcpCli.GetStream()
         Dim sr As New StreamReader(ns)
         Dim receivedData As String = sr.ReadLine()

         If receivedData <> "" Then
            ' Read a file with this name from the C:\docs directory
            Dim fileName As String = Path.Combine("c:\docs", receivedData)
            Console.WriteLine("Reading file {0}...", fileName)

            Dim resultData As String = Nothing
            Try
               resultData = File.ReadAllText(fileName)
            Catch ex As Exception
               resultData = "*** ERROR: " & ex.Message
            End Try
            SendData(ns, resultData)
         End If
         ' Release resources and close the NetworkStream.
         sr.Close()
         ns.Close()
         tcpCli.Close()
         ' Exit if the client sent an empty string.
         If receivedData = "" Then Exit Do
      Loop
      ' Reject client requests from now on.
      tcpList.Stop()
   End Sub

   ' Send a length-prefixed string.
   Sub SendData(ByVal ns As NetworkStream, ByVal data As String)
      ' Send it back to the client.
      Dim sw As New StreamWriter(ns)
      sw.WriteLine(data.Length)
      sw.Write(data)
      sw.Flush()                            ' This is VERY important.
      sw.Close()
   End Sub


End Module
