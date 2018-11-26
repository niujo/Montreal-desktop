using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Pais
    {
        [JsonProperty("ID_PAIS")]
        public int? id_pais { get; set; }

        [JsonProperty("NOMBRE")]
        public String nombre { get; set; }
    }
}
