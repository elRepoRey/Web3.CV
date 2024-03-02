using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delgado.Shared
{
    public interface IBsonId
    {       
            [BsonId]          
            public Guid Id { get; set; }
    }
}
