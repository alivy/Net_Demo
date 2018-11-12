using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point.Elasticsearch
{
    public class ElasticsearchGet
    {
        //链接elasticsearc
        //你可以通过单个节点或者指定多个节点使用连接池链接到Elasticsearch集群，使用连接池要比单个节点链接到Elasticsearch更有优势，比如支持负载均衡、故障转移等。
        /// <summary>
        /// 通过单点链接
        /// </summary>
        public void SinglePointLink()
        {
            var node = new Uri("http://myserver:9200");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

        }
        /// <summary>
        /// 通过连接池链接
        /// </summary>
        public void ConnectionPoolLink()
        {
            var nodes = new Uri[]{
            new Uri("http://myserver1:9200"),
            new Uri("http://myserver2:9200"),
            new Uri("http://myserver3:9200")
            };
            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
        }

        public void query() {
            //可以通过ConnectionSettings使用.DefaultIndex()，来指定默认索引。当一个请求里没有指定具体索引时，NEST将请求默认索引
            var settings = new ConnectionSettings().DefaultIndex("defaultindex");

            //可以通过ConnectionSettings使用.MapDefaultTypeIndices()，来指定被映射为CLR类型的索引。
            //注意：通过.MapDefaultTypeIndices()指定索引的优先级要高于通过.DefaultIndex()指定索引，并且更适合简单对象（POCO）
            //var settings = new ConnectionSettings().MapDefaultTypeIndices(m => m .Add(typeof(Project), "projects")
        }


    }
}
