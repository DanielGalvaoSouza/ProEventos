using Newtonsoft.Json;
using System;

namespace ProEventos.Persistence
{
    public static class ToThisClass<T> where T : class
    {
        public static T CastThisClass<U>(object param)
        {
            T objectCasted = null;
            U cast;

            try
            {
                cast = (U)param;
                objectCasted = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(cast));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return objectCasted;

        }
    }
}
