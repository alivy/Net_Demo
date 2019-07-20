using ProgramService.ServiceMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ProgramService
{
   public  class Program
    {
        static void Main(string[] args)
        {
            //服务的地址
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");
            //承载服务的宿主
            ServiceHost selfHost = new ServiceHost(typeof(IServiceMe), baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(typeof(IServiceMe), new WSHttpBinding(), "Calculator");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("input<exit> to terminate service.");
                Console.WriteLine();
                while ("exit" == Console.ReadLine())
                {
                    selfHost.Close();
                }
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.Message);
                selfHost.Abort();
                Console.ReadLine();
            }
        }
    }
}
