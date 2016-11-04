using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CuratorJournal.Logic.EnumWork
{
    public static class RussianEnumUtils
    {
        public static List<TEnum> GetValues<TEnum>() where TEnum : IRussianEnum
        {
            return GetValues(typeof(TEnum)).Select(val => (TEnum)val).ToList();
        }

        internal static List<IRussianEnum> GetValues(Type enumType)
        {
            FieldInfo[] fields = enumType.GetFields();
            List<IRussianEnum> enumValues = new List<IRussianEnum>();
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.IsStatic && fieldInfo.IsPublic && enumType.IsAssignableFrom(fieldInfo.FieldType))
                {
                    IRussianEnum enumValue = (IRussianEnum)fieldInfo.GetValue(null);
                    enumValues.Add(enumValue);
                }
            }
            return enumValues;
        }

        public static TEnum FindById<TEnum>(long? id) where TEnum : class, IRussianEnum
        {
            return (TEnum)FindById(typeof(TEnum), id);
        }

        internal static IRussianEnum FindById(Type enumType, long? id)
        {
            if (id == null)
            {
                return null;
            }
            List<IRussianEnum> values = GetValues(enumType);
            foreach (IRussianEnum value in values)
            {
                if (value.Id == id)
                {
                    return value;
                }
            }
            return null;
        }

        public static bool Is<TEnum>(this TEnum t, TEnum val) where TEnum : class, IRussianEnum
        {
            if (t == null && val == null)
            {
                return true;
            }
            if (t == null || val == null)
            {
                return false;
            }
            return t.Id == val.Id;
        }

        public static bool In<TEnum>(this TEnum t, params TEnum[] values) where TEnum : class, IRussianEnum
        {
            foreach (TEnum val in values)
            {
                if (t.Is(val))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool In<TEnum>(this TEnum t, List<TEnum> values) where TEnum : class, IRussianEnum
        {
            return In(t, values.ToArray());
        }

        //todo: simplify syntax
        public static T GetPropertyValue<T>(T value, long? id) where T : class, IRussianEnum
        {
            return value ?? FindById<T>(id);
        }

        public static string GetFullName(this IRussianEnum val)
        {
            if (val == null)
            {
                return "null";
            }
            return string.Format("{0} - {1}", val.Id, val.Name);
        }
    }
}
