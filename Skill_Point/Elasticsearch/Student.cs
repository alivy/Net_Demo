
using Nest;
using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point.Elasticsearch
{
    [Nest.ElasticsearchType(Name = "student")]
    public class Student

    {

        //[Nest.String(Index = FieldIndexOption.NotAnalyzed)]
        public string Id { get; set; }

        //[Nest.String(Analyzer = "standard")]
        public string Name { get; set; }

        //[Nest.String(Analyzer = "standard")]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

    }

    public class AutoMap
    {
        public AutoMap()
        {

            var descriptor = new CreateIndexDescriptor("db_student").Settings(s => s.NumberOfShards(5).NumberOfReplicas(1)).Mappings(ms => ms.Map<Student>(m => m.AutoMap()));

            
        }

    }
}
