using Base;
using System;

namespace CurumimClient.EventArgsForms
{
    public class LoginSucessEventArgs:EventArgs
    {
       public MessageEventArgs MessageEventArgs { get; set; }
    }
}
