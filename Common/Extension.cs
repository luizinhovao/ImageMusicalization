﻿using Common.Generation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extension
    {
        /// <summary>
        /// Retorna a descrição do Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Remove o status da lista
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static List<IState> RemoveState(this List<IState> a, IState b)
        {
            List<IState> returnValue = new List<IState>();

            if (a != null)
                a.ForEach(c => { if (b.Guid != c.Guid) returnValue.Add(c); });

            return returnValue;
        }

    }
}

namespace System.Collections.Generic
{
	public static class Extension
	{
		public static bool IsNullOrEmpty(this ICollection collection)
		{
			return collection == null || collection.Count <= 0;
		}
	}
}

namespace System
{
	public static class Extension
	{
		public static void ThrowIfNull(this object obj, string nameof)
		{
			if (obj == null)
				throw new ArgumentException(nameof);
		}
	}
}
