using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OneWcfService
{

    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceMe”。
    //协定
    //[ServiceContract(//CallbackContract =typeof(ICallBack),//双工时的返回协定
    //    ConfigurationName = "OneWcfService",//配置文件重的服务名
    //    Name = "IOneWcfService",//webservice描述文件重的portType名
    //    Namespace = "http://SampleWcfTest",//webservice描述文件重的portType命名空间
    //    ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign,//保护等级
    //    SessionMode = SessionMode.Allowed)]//设置会话的支持模式
    [ServiceContract]
    public interface IServiceMe
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        //定义方法的操作，带了该特性才会被公布
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        double Subtract(double n1, double n2);

        [OperationContract]
        double Multiply(double n1, double n2);

        [OperationContract]
        double Divide(double n1, double n2);

        // TODO: 在此添加您的服务操作
    }

    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void Reply(string responseToGreeting);
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
