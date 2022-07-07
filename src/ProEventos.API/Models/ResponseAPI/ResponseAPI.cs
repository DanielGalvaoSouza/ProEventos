using System.Collections.Generic;

namespace ProEventos.Application.ResponseAPI
{
    public class ResponseObject<T>
    {
        public bool IsProcessSucessfuly { get; set; }
        public string MessageProcess { get; set; }
        public T EntityObject { get; set; }
        public IEnumerable<T> ListEntityObject { get; set; }
    }
}
