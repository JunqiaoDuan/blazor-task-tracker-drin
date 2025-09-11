using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerPro.Service.Shared.Helpers
{
    public static class ReflectionHelper
    {
        public static void CopyTo<TSource, TTarget>(TSource source, TTarget destination)
        {
            if (source == null || destination == null)
            {
                return;
            }

            var sourceProperties = typeof(TSource)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead);

            var targetProperties = typeof(TTarget)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite);

            foreach (var sourceProp in sourceProperties)
            {
                var targetProp = targetProperties.FirstOrDefault(tp =>
                    tp.Name == sourceProp.Name &&
                    tp.PropertyType.IsAssignableFrom(sourceProp.PropertyType));

                if (targetProp != null)
                {
                    var value = sourceProp.GetValue(source, null);
                    targetProp.SetValue(destination, value, null);
                }
            }
        }

        public static TTarget CopyTo<TSource, TTarget>(TSource source)
            where TTarget : new()
        {
            if (source == null)
                return default!;

            var destination = new TTarget();

            var sourceProperties = typeof(TSource)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead);

            var targetProperties = typeof(TTarget)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite);

            foreach (var sourceProp in sourceProperties)
            {
                var targetProp = targetProperties.FirstOrDefault(tp =>
                    tp.Name == sourceProp.Name &&
                    tp.PropertyType.IsAssignableFrom(sourceProp.PropertyType));

                if (targetProp != null)
                {
                    var value = sourceProp.GetValue(source, null);
                    targetProp.SetValue(destination, value, null);
                }
            }

            return destination;
        }

    }
}
