﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AbCorFlorProyectoP2EasyTicketsMAUI.Models
{
    

    public class ACFEventos
    {
        [PrimaryKey, AutoIncrement] 
        public int LocalId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } 

        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("url")] 
        public string Url { get; set; }
    }
}
