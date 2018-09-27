using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.IO;
using Unity;

namespace Knowledge_Point知识点.Unity
{

    /// <summary>
    /// Unity IOC单例模式 
    /// </summary>
    public class UnitysSingleton
    {
        //单例
        //private static UnitySingleton instance;

        ////ioc容器
        //public IUnityContainer container;

        //获取单例
        //public static UnitySingleton getInstance()
        //{
        //    if (instance == null || instance.container == null)
        //    {
        //        //找配置文件的路径
        //        string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Unity.config\\Unity.config.xml");

        //        var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
        //        //从config文件中读取配置信息
        //        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        //        //获取指定名称的配置节
        //        UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
        //        instance = new UnitySingleton()
        //        {
        //            //container = new UnityContainer().LoadConfiguration((UnityConfigurationSection)ConfigurationManager.GetSection("unity"), "MyContainer")
        //            container = new UnityContainer().LoadConfiguration(section, "MyContainer")
        //            //container = new UnityContainer()
        //        };
        //        //instance.container.RegisterType<IExampleClass, ExampleClass>();
        //    }
        //    return instance;
        //}

        ////IOC注入实体
        //public static T GetInstanceDAL<T>()
        //{
        //    return getInstance().container.Resolve<T>();
        //}
    }
}

