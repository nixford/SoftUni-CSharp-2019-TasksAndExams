using System;
using System.Threading.Tasks;

namespace SIS.HTTP
{

    public interface IHttpServer
    {
        Task StartAsync ();
        // The key word async must be used in the implementation of the method
        // in the classes whic inherit the interface

        Task ResetAsync();
        // The key word async must be used in the implementation of the method
        // in the classes whic inherit the interface
        void Stop();
    
    }
}
