﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicX.Services.Mapping
{
    public static class EnumerableMappingExtensions
    {
        public static IEnumerable<TDestination> To<TDestination>(
            this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var src in source)
            {
                yield return AutoMapperConfig.MapperInstance.Map<TDestination>(src);
            }
        }
    }
}
