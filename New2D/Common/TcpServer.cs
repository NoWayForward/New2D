using New2D.GameObjects.Character.NPC.Enemy;
using System.IO.Pipes;

namespace New2D.Helpers;

public class TcpServer
{
    NamedPipeServerStream server;

    public void OpenStream(String name)
    {
        server = new NamedPipeServerStream(name, PipeDirection.InOut,  1, PipeTransmissionMode.Byte);
        server.WaitForConnection();
    }
    
    public void CloseStream()
    {
        server.Close();
    }

    public EnemyActions nextAction()
    {
        return (EnemyActions)server.ReadByte();
    }
}