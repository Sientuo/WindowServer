using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowShare
{
    public class ContainerHelper
    {
        public static IContainer IBuilder { get; set; }

        public static IContainer RegisterContainer()
        {
            var Builder = new ContainerBuilder();//容器构造器 组件中的类型通过此对象注册到容器中
             //注册所有实现了 IDependency 接口的类型
            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").Select(Assembly.LoadFrom).ToArray().Where(c => c.ManifestModule.Name.Contains("Window")).ToArray();
            // = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();
            Type baseType = typeof(IDependency);
            Builder.RegisterAssemblyTypes(assemblies)
            //.Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract || type.GetCustomAttribute(typeof(ServiceAttribute)) != null)
            .Where(t => baseType.IsAssignableFrom(t) || baseType.IsAssignableFrom(t) && !t.IsAbstract)
            .AsSelf().AsImplementedInterfaces()
            .PropertiesAutowired().InstancePerLifetimeScope();
            IBuilder = Builder.Build();
            return IBuilder;
        }

        public static IContainer GetContainer()
        {
            return IBuilder ?? RegisterContainer();
        }
    }
}
