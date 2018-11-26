using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Inscripcion
    {
        [JsonProperty("ID_INSCRIPCION")]
        public int? id_inscripcion { get; set; }

        [JsonProperty("ID_PROGRAMA")]
        public int? id_programa { get; set; }

        [JsonProperty("ID_ALUMNO")]
        public int? id_alumno { get; set; }
    }
}
