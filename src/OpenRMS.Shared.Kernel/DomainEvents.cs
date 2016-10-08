using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Shared.Kernel
{
    public static class DomainEvents
    {
        //private static List<Type> _staticHandlers;

        static DomainEvents()
        {
            var currentType = typeof(DomainEvents);
            var currentTypeInfo = currentType.GetTypeInfo();
            var assembly = currentTypeInfo.Assembly;
            var typesInAssembly = assembly.GetTypes();

            // When .Net core allows!
            //_staticHandlers = typesInAssembly
                //.Where(type => type.GetInterfaces().Any(type2 => type.IsGenericInterface && type2.GetGenericTypedefinition ==))
        }

        public static void Dispatch<TEvent>(TEvent domainEvent)
            where TEvent : IDomainEvent
        {
            //foreach (Type staticHandler in _staticHandlers)
            //{
            //    // When .Net core allows!
            //    //if (typeof(IDomainEventHandler<TEvent>).IsAssignableFrom(staticHandler))
            //    //{
            //    //    IDomainEventHandler<TEvent> instance =
            //    //        (IDomainEventHandler<TEvent>) Activator.CreateInstance(staticHandler);
            //    //}
            //}
        }
    }
}
