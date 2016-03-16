using System;

using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;

using ServiceLib;

namespace ServerLib {

    public class Server {

        private int Port = 14000;
        private readonly IScsServiceApplication Service;

        public Server() {
            try {
                this.Service = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(Port));
            } catch (Exception) {
                //TODO
            }
        }

        public Server(int port) {
            this.Port = port;
        }

        public void Start() {
            try {
                this.Service.AddService<IServiceOperations, ServiceOperations>(new ServiceOperations());

                this.Service.ClientConnected    += Service_ClientConnected;
                this.Service.ClientDisconnected += Service_ClientDisconnected;
                this.Service.Start();
            } catch (Exception) {
                //TODO
            }
        }

        public void Stop() {
            this.Service.Stop();
        }

        private void Service_ClientDisconnected(object sender, ServiceClientEventArgs e) {
            //TODO
        }

        private void Service_ClientConnected(object sender, ServiceClientEventArgs e) {
            //TODO
        }

    }

}