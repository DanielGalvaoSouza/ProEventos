using System.Collections.Generic;

namespace ProEventos.API.Models.ResponseAPI
{
    public class ResponseAPI<T>
    {
        public bool IsProcessSucessfuly { get; set; }
        public string MessageProcess { get; set; }
        public T EntityObject { get; set; }
        public IEnumerable<T> ListEntityObject { get; set; }
    }
}
