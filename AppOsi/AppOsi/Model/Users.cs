using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppOsi.Model
{
    //[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Users
    {
        //[JsonProperty(PropertyName = "usr_ci")]
        public string Usr_ci { get; set; }
        
        //[JsonProperty(PropertyName = "usr_nombres")]
        public string Usr_nombres { get; set; }
        
        //[JsonProperty(PropertyName = "usr_apellidos")]
        public string Usr_apellidos { get; set; }
        
        //[JsonProperty(PropertyName = "usr_clave")]
        public string Brig_nombre { get; set; }
        public int Brig_id { get; set; }
        

    }
}
