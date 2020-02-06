using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace BinaryTreeTask
{
    public class Node<T> : IComparable<Node<T>>
        where T : IComparable
    {
        private static readonly ILog log = 
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private static ILoggerRepository logRepository = 
            LogManager.GetRepository(Assembly.GetEntryAssembly());

        private static FileInfo fileInfo = new FileInfo("log4net.config");

        public T Data { get; set; }
        public Node<T> NodeLeft { get; set; }
        public Node<T> NodeRight { get; set; }
        
        public Node() 
        {
            XmlConfigurator.Configure(logRepository, fileInfo);
            log.Info($"New Empty Node was created at {DateTime.Now}");
        }

        public Node(T data)
        {
            Data = data;

            XmlConfigurator.Configure(logRepository, fileInfo);
            log.Info($"New Node {data.ToString()} was created at {DateTime.Now}");
        }

        public int CompareTo(Node<T> other)
        {
            if (other == null) return 1;

            return Data.CompareTo(other.Data);
        }

        public override string ToString()
        {
            return $"Node: {Data.ToString()}, with: " +
                $"[Left node: {NodeLeft?.Data.ToString() ?? "Empty"}] " +
                $"and [Right node: {NodeRight?.Data.ToString() ?? "Empty"}]";
        }

        public static bool operator > (Node<T> node1, Node<T> node2)
        {
            XmlConfigurator.Configure(logRepository, fileInfo);

            if (node1 == null || node2 == null)
            {
                log.Error("ArgumentNullException - Nodes should not be null.");
                throw new ArgumentNullException("Nodes should not be null.");
            }

            return node1.CompareTo(node2) == 1;
        }

        public static bool operator < (Node<T> node1, Node<T> node2)
        {
            XmlConfigurator.Configure(logRepository, fileInfo);

            if (node1 == null || node2 == null)
            {
                log.Error("ArgumentNullException - Nodes should not be null.");
                throw new ArgumentNullException("Nodes should not be null.");
            }

            return node1.CompareTo(node2) == -1;
        }
    }
}