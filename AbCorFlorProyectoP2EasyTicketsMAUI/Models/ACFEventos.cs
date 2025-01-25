using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Models
{
    public class ACFEventos
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class ACFEmbedded
    {
        public List<ACFEventos> Events { get; set; }
    }

    public class ACFRoot
    {
        [JsonProperty("_embedded")]
        public ACFEmbedded Embedded { get; set; }
    }
}
