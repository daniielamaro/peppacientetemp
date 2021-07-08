using API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Request
{
    public class SetPhotoUser
    {
        public Guid IdUser { get; set; }
        public Arquivo Foto { get; set; }
    }
}
